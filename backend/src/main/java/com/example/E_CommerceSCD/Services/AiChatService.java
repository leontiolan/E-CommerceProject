package com.example.E_CommerceSCD.Services;

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

@Service
@RequiredArgsConstructor
public class AiChatService {

    private final ObjectMapper objectMapper;

    @Value("${gemini.api.key}")
    private String apiKey;

    @Value("${gemini.api.url}")
    private String apiUrl;

    public String getChatResponse(String userPrompt) {
        try {
            // Simple system prompt to avoid token usage
            return callGeminiApi("You are a helpful assistant.", userPrompt);
        } catch (Exception e) {
            e.printStackTrace();
            return "Error: " + e.getMessage();
        }
    }

    private String callGeminiApi(String systemInstruction, String userMessage) throws Exception {
        ObjectNode rootNode = objectMapper.createObjectNode();
        ArrayNode contentsArray = rootNode.putArray("contents");
        ObjectNode contentNode = contentsArray.addObject();
        ArrayNode partsArray = contentNode.putArray("parts");

        partsArray.addObject().put("text", userMessage);

        String jsonBody = objectMapper.writeValueAsString(rootNode);

        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(apiUrl + "?key=" + apiKey))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(jsonBody))
                .build();

        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());

        if (response.statusCode() != 200) {
            System.err.println("Gemini Error: " + response.body());
            return "API Error (" + response.statusCode() + "). Check console.";
        }

        JsonNode responseNode = objectMapper.readTree(response.body());
        if (responseNode.has("candidates") && responseNode.get("candidates").size() > 0) {
            JsonNode candidate = responseNode.get("candidates").get(0);
            if (candidate.has("content") && candidate.get("content").has("parts")) {
                return candidate.get("content").get("parts").get(0).get("text").asText();
            }
        }

        return "No response.";
    }
}