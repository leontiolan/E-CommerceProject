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
import java.util.Map;
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
            // 1. Build the context string with Category summaries + Product details
            String stockContext = buildStockContext();

            // 2. Create the system prompt
            String systemInstruction = "You are a helpful customer support assistant for an E-Commerce shop. " +
                    "Use the following inventory data to answer user questions.\n" +
                    "The data includes a summary of categories and a list of specific products.\n\n" +
                    stockContext + "\n\n" +
                    "Rules:\n" +
                    "- If asked about category counts (e.g. 'how many phones'), use the Category Summary.\n" +
                    "- If asked about specific products, check the Product List for price and stock.\n" +
                    "- Be concise and polite.";

            return callGeminiApi(systemInstruction, userPrompt);

        } catch (Exception e) {
            e.printStackTrace();
            return "Error processing your request: " + e.getMessage();
        }
    }

    private String buildStockContext() {
        List<Product> products = productRepository.findAll();
        if (products.isEmpty()) return "No products currently available.";

        StringBuilder sb = new StringBuilder();

        // --- Part A: Category Summary ---
        Map<String, Long> categoryCounts = products.stream()
                .map(p -> p.getCategory().getName())
                .collect(Collectors.groupingBy(c -> c, Collectors.counting()));

        sb.append("=== Category Summary ===\n");
        categoryCounts.forEach((cat, count) ->
                sb.append(String.format("- %s: %d items\n", cat, count))
        );
        sb.append("\n");

        // --- Part B: Product List ---
        sb.append("=== Product List ===\n");
        for (Product p : products) {
            sb.append(String.format("- Product: %s | Category: %s | Price: $%.2f | Stock: %d\n",
                    p.getName(), p.getCategory().getName(), p.getPrice(), p.getStockQuantity()));
        }
        return sb.toString();
    }

    private String callGeminiApi(String systemInstruction, String userMessage) throws Exception {
        ObjectNode rootNode = objectMapper.createObjectNode();
        ArrayNode contentsArray = rootNode.putArray("contents");
        ObjectNode contentNode = contentsArray.addObject();
        ArrayNode partsArray = contentNode.putArray("parts");

        String combinedText = systemInstruction + "\n\nUser: " + userMessage;
        partsArray.addObject().put("text", combinedText);

        String jsonBody = objectMapper.writeValueAsString(rootNode);

        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(apiUrl + "?key=" + apiKey))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(jsonBody))
                .build();

        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        if (response.statusCode() != 200) {
            return "AI Provider Error (" + response.statusCode() + "): " + response.body();
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