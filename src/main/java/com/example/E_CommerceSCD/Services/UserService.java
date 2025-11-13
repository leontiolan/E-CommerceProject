package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.UserDTO;
import com.example.E_CommerceSCD.Entity.Role;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class UserService {
    public List<UserDTO> getAllUsers() {
        return List.of(
                UserDTO.builder().id(1L).username("admin").email("admin@test.com").role(Role.ADMIN).build()
        );
    }
}