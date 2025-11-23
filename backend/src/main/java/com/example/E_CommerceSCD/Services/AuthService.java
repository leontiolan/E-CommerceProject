package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.AuthResponseDTO;
import com.example.E_CommerceSCD.DTOs.LoginDTO;
import com.example.E_CommerceSCD.DTOs.RegisterDTO;
import com.example.E_CommerceSCD.Entity.Role;
import com.example.E_CommerceSCD.Entity.ShoppingCart;
import com.example.E_CommerceSCD.Entity.User;
import com.example.E_CommerceSCD.Repositories.ShoppingCartRepository;
import com.example.E_CommerceSCD.Repositories.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class AuthService {

    private final UserRepository userRepository;
    private final ShoppingCartRepository shoppingCartRepository;
    private final PasswordEncoder passwordEncoder;
    private final JwtService jwtService;
    private final AuthenticationManager authenticationManager;

    public AuthResponseDTO register(RegisterDTO request) {
        var user = User.builder()
                .username(request.getUsername())
                .email(request.getEmail())
                .password(passwordEncoder.encode(request.getPassword()))
                .role(Role.USER)
                .build();

        User savedUser = userRepository.save(user);

        ShoppingCart cart = ShoppingCart.builder().user(savedUser).build();
        shoppingCartRepository.save(cart);

        var token = jwtService.generateToken(user);
        return AuthResponseDTO.builder()
                .token(token)
                .username(user.getUsername())
                .role(user.getRole())
                .build();
    }

    public AuthResponseDTO login(LoginDTO request) {
        authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(
                        request.getUsername(),
                        request.getPassword()
                )
        );

        var user = userRepository.findByUsername(request.getUsername())
                .orElseThrow();

        var token = jwtService.generateToken(user);
        return AuthResponseDTO.builder()
                .token(token)
                .username(user.getUsername())
                .role(user.getRole())
                .build();
    }

    public AuthResponseDTO registerAdmin(RegisterDTO request) {
        var user = User.builder()
                .username(request.getUsername())
                .email(request.getEmail())
                .password(passwordEncoder.encode(request.getPassword()))
                .role(Role.ADMIN) // <--- Set Role to ADMIN
                .build();

        User savedUser = userRepository.save(user);

        // Admins might not need a shopping cart, but we create one to avoid null pointer issues if logic is shared
        ShoppingCart cart = ShoppingCart.builder().user(savedUser).build();
        shoppingCartRepository.save(cart);

        var token = jwtService.generateToken(user);
        return AuthResponseDTO.builder()
                .token(token)
                .username(user.getUsername())
                .role(user.getRole())
                .build();
    }

}