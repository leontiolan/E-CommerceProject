package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.ChangePasswordRequestDTO;
import com.example.E_CommerceSCD.DTOs.OrderSummaryDTO;
import com.example.E_CommerceSCD.DTOs.UserDTO;
import com.example.E_CommerceSCD.DTOs.UserDetailAdminDTO;
import com.example.E_CommerceSCD.Entity.User;
import com.example.E_CommerceSCD.Repositories.OrderRepository;
import com.example.E_CommerceSCD.Repositories.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository userRepository;
    private final OrderRepository orderRepository;
    private final PasswordEncoder passwordEncoder;

    public User getCurrentUser() {
        String username = SecurityContextHolder.getContext().getAuthentication().getName();
        return userRepository.findByUsername(username)
                .orElseThrow(() -> new UsernameNotFoundException("Current user not found"));
    }

    public UserDTO getCurrentUserProfile() {
        User user = getCurrentUser();
        return mapToUserDTO(user);
    }

    public void changeUserPassword(ChangePasswordRequestDTO request) {
        User user = getCurrentUser();

        if (!passwordEncoder.matches(request.getCurrentPassword(), user.getPassword())) {
            throw new IllegalStateException("Wrong current password");
        }

        user.setPassword(passwordEncoder.encode(request.getNewPassword()));
        userRepository.save(user);
    }

    public List<UserDTO> getAllUsers() {
        return userRepository.findAll().stream()
                .map(this::mapToUserDTO)
                .collect(Collectors.toList());
    }

    public UserDetailAdminDTO getUserDetailsForAdmin(Long id) {
        User user = userRepository.findById(id)
                .orElseThrow(() -> new UsernameNotFoundException("User not found with id: " + id));

        List<OrderSummaryDTO> orders = orderRepository.findByUserOrderByOrderDateDesc(user)
                .stream()
                .map(order -> OrderSummaryDTO.builder()
                        .id(order.getId())
                        .orderDate(order.getOrderDate())
                        .status(order.getStatus())
                        .orderPrice(order.getOrderPrice())
                        .build())
                .collect(Collectors.toList());

        return UserDetailAdminDTO.builder()
                .id(user.getId())
                .username(user.getUsername())
                .email(user.getEmail())
                .role(user.getRole())
                .orders(orders)
                .build();
    }

    private UserDTO mapToUserDTO(User user) {
        return UserDTO.builder()
                .id(user.getId())
                .username(user.getUsername())
                .email(user.getEmail())
                .role(user.getRole())
                .build();
    }
}