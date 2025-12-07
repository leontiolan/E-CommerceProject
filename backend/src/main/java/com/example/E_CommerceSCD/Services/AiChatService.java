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

    private final ObjectMapper objectMapper;
    private final ProductRepository productRepository;

    @Value("${gemini.api.key}")
    private String apiKey;

    @Value("${gemini.api.url}")
    private String apiUrl;

    public String getChatResponse(String userPrompt) {
        try {
            String stockContext = buildSmartStockContext(userPrompt);

            String systemInstruction = "You are a customer support assistant for an E-Commerce shop. " +
                    "Answer based ONLY on the product data provided below. " +
                    "If the product is not in the list, apologize and say you don't have that information.\n\n" +
                    "--- RELEVANT PRODUCT DATA ---\n" +
                    stockContext;

            return callGeminiApi(systemInstruction, userPrompt);

        } catch (Exception e) {
            e.printStackTrace();
            return "I'm having trouble checking the stock right now.";
        }
    }

    private String buildSmartStockContext(String userQuery) {
        List<Product> allProducts = productRepository.findAll();
        if (allProducts.isEmpty()) return "No products found in database.";

        String query = userQuery.toLowerCase();

        List<Product> relevantProducts = allProducts.stream()
                .filter(p -> (p.getName() != null && query.contains(p.getName().toLowerCase())) ||
                        (p.getCategory() != null && query.contains(p.getCategory().getName().toLowerCase())) ||
                        (p.getDescription() != null && query.contains(p.getDescription().toLowerCase())))
                .limit(10)
                .collect(Collectors.toList());

        if (relevantProducts.isEmpty()) {
            relevantProducts = allProducts.stream().limit(5).collect(Collectors.toList());
        }

        StringBuilder sb = new StringBuilder();
        for (Product p : relevantProducts) {
            sb.append(String.format("- %s | Price: $%.2f | Stock: %d\n",
                    p.getName(), p.getPrice(), p.getStockQuantity()));
        }
        return sb.toString();
    }

    private String callGeminiApi(String systemInstruction, String userMessage) throws Exception {
        ObjectNode rootNode = objectMapper.createObjectNode();
        ArrayNode contentsArray = rootNode.putArray("contents");
        ObjectNode contentNode = contentsArray.addObject();
        ArrayNode partsArray = contentNode.putArray("parts");

        String combinedText = systemInstruction + "\n\nUser Question: " + userMessage;
        partsArray.addObject().put("text", combinedText);

        String jsonBody = objectMapper.writeValueAsString(rootNode);

        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(apiUrl + "?key=" + apiKey))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(jsonBody))
                .build();

        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        if (response.statusCode() == 429) {
            return "I'm a bit overwhelmed right now (Quota Exceeded). Please wait a minute and try again.";
        }

        if (response.statusCode() != 200) {
            System.err.println("AI Error: " + response.body());
            return "I encountered a technical issue. Please try again later.";
        }

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