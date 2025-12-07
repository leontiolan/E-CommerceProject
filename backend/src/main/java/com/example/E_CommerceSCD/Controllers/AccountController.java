package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.ChangePasswordRequestDTO;
import com.example.E_CommerceSCD.DTOs.UserDTO;
import com.example.E_CommerceSCD.Services.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/account")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('USER')")
public class AccountController {

    private final UserService userService;

    @GetMapping("/me")
    public ResponseEntity<UserDTO> getMyProfile() {
        return ResponseEntity.ok(userService.getCurrentUserProfile());
    }

    @PutMapping("/change-password")
    public ResponseEntity<Void> changeMyPassword(@RequestBody ChangePasswordRequestDTO request) {
        userService.changeUserPassword(request);
        return ResponseEntity.ok().build();
    }
}