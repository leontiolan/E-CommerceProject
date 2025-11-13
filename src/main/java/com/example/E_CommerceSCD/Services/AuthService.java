package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.AuthResponseDTO;
import com.example.E_CommerceSCD.DTOs.LoginDTO;
import com.example.E_CommerceSCD.DTOs.RegisterDTO;
import com.example.E_CommerceSCD.Entity.Role;
import org.springframework.stereotype.Service;

@Service
public class AuthService {

    public AuthResponseDTO register(RegisterDTO request) {
        // Placeholder logic
        return AuthResponseDTO.builder()
                .token("dummy-jwt-token-for-testing")
                .username(request.getUsername())
                .role(Role.USER)
                .build();
    }

    public AuthResponseDTO login(LoginDTO request) {
        // Placeholder logic
        return AuthResponseDTO.builder()
                .token("dummy-jwt-token-for-testing")
                .username(request.getUsername())
                .role(Role.USER)
                .build();
    }
}