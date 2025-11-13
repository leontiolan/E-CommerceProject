package com.example.E_CommerceSCD.Services;

import org.springframework.stereotype.Service;

@Service
public class AiChatService {
    public String getChatResponse(String prompt) {
        return "I am a placeholder AI. You said: " + prompt;
    }
}