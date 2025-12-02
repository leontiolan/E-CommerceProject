package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.node.ArrayNode;
import com.fasterxml.jackson.databind.node.ObjectNode;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class AiChatService {

    private final ProductRepository productRepository;
    private final ObjectMapper objectMapper; // Spring Boot provides this automatically

    @Value("${gemini.api.key}")
    private String apiKey;

    @Value("${gemini.api.url}")
    private String apiUrl;

    public String getChatResponse(String userPrompt) {
        try {
            // 1. RAG: Fetch relevant data from DB
            String dbContext = findRelevantProductInfo(userPrompt);

            // 2. Construct the prompt for Gemini
            String finalSystemPrompt = "You are a helpful customer support assistant for an E-Commerce shop. " +
                    "If the user asks about products, use the provided context to answer. " +
                    "If the context is empty or doesn't match, politely say you don't have that info but offer general help. " +
                    "You can also answer general off-topic questions (like 'what is 2+2') briefly." +
                    "\n\nCONTEXT FROM DATABASE:\n" + dbContext;

            // 3. Call Gemini API
            return callGeminiApi(finalSystemPrompt, userPrompt);

        } catch (Exception e) {
            e.printStackTrace();
            return "Sorry, I'm having trouble connecting to my brain right now. Please try again later.";
        }
    }

    private String findRelevantProductInfo(String prompt) {
        String lowerPrompt = prompt.toLowerCase();

        // Simple keyword extraction (split by space) to find potential matches
        String[] words = lowerPrompt.split("\\s+");
        List<Product> matches = null;

        for (String word : words) {
            // Skip common short words to avoid fetching everything
            if (word.length() > 3) {
                matches = productRepository.findAll((root, query, cb) ->
                        cb.like(cb.lower(root.get("name")), "%" + word + "%")
                );
                if (!matches.isEmpty()) break; // Stop at first match group for efficiency
            }
        }

        if (matches == null || matches.isEmpty()) {
            return "No specific products found matching the user's keywords.";
        }

        // Format the products into a string for the AI to read
        return matches.stream()
                .limit(5) // Limit to 5 items to save tokens
                .map(p -> String.format("- %s: $%.2f (Stock: %d) - %s",
                        p.getName(), p.getPrice(), p.getStockQuantity(), p.getDescription()))
                .collect(Collectors.joining("\n"));
    }

    private String callGeminiApi(String systemInstruction, String userMessage) throws Exception {
        // Build JSON Body using Jackson
        // Structure: { "contents": [{ "parts": [{ "text": "..." }] }] }
        ObjectNode rootNode = objectMapper.createObjectNode();
        ArrayNode contentsArray = rootNode.putArray("contents");
        ObjectNode contentNode = contentsArray.addObject();
        ArrayNode partsArray = contentNode.putArray("parts");

        // Combine system instruction + user message into one block for the model
        String combinedText = systemInstruction + "\n\nUSER QUESTION: " + userMessage;
        partsArray.addObject().put("text", combinedText);

        String jsonBody = objectMapper.writeValueAsString(rootNode);

        // Build Request
        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(apiUrl + "?key=" + apiKey))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(jsonBody))
                .build();

        // Send Request
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        if (response.statusCode() != 200) {
            return "Error from AI Provider: " + response.statusCode();
        }

        // Parse Response
        // Structure: { "candidates": [ { "content": { "parts": [ { "text": "..." } ] } } ] }
        JsonNode responseNode = objectMapper.readTree(response.body());
        if (responseNode.has("candidates") && responseNode.get("candidates").size() > 0) {
            JsonNode candidate = responseNode.get("candidates").get(0);
            if (candidate.has("content") && candidate.get("content").has("parts")) {
                return candidate.get("content").get("parts").get(0).get("text").asText();
            }
        }

        return "I didn't get a clear response.";
    }
}