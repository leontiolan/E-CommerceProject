package com.example.E_CommerceSCD.DTOs;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class CartItemDetailsDTO {
    private Long cartItemId;
    private Long productId;
    private String productName;
    private Double productPrice;
    private int quantity;
}
