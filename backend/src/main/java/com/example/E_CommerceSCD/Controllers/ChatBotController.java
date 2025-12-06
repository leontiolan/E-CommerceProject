package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.ChatRequestDTO;
import com.example.E_CommerceSCD.DTOs.ChatResponseDTO;
import com.example.E_CommerceSCD.Services.AiChatService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/chat")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
public class ChatBotController {

    private final AiChatService aiChatService;

    @PostMapping
    public ResponseEntity<ChatResponseDTO> chatWithAi(
            @RequestBody ChatRequestDTO chatRequest
    ) {
        String response = aiChatService.getChatResponse(chatRequest.getPrompt());
        return ResponseEntity.ok(new ChatResponseDTO(response));
    }
}