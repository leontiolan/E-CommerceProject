package com.example.E_CommerceSCD.DTOs;

import com.example.E_CommerceSCD.Entity.Role;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserDetailAdminDTO {
    private Long id;
    private String username;
    private String email;
    private Role role;
    private List<OrderSummaryDTO> orders;
}
