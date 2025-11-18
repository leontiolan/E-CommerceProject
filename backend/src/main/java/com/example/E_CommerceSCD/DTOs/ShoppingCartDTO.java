package com.example.E_CommerceSCD.DTOs;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ShoppingCartDTO {
    private Long id;
    private List<CartItemDetailsDTO> cartItemDetailsDTOList;
    private Double totalCartPrice;
}
