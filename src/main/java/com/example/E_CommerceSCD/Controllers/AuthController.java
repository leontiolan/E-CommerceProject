package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.AuthResponseDTO;
import com.example.E_CommerceSCD.DTOs.LoginDTO;
import com.example.E_CommerceSCD.DTOs.RegisterDTO;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/auth")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
public class AuthController {

    private final AuthService authService;

    @PostMapping("/register")
    public ResponseEntity<AuthResponseDTO> register (@RequestBody RegisterDTO request){
        return ResponseEntity.ok(authService.register(request));
    }

    @PostMapping("/login")
    public ResponseEntity<AuthResponseDTO> login (@RequestBody LoginDTO request){
        return ResponseEntity.ok(authService.login(request));
    }
}
