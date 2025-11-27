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
public class ProductCreateUpdateDTO {
    private String name;
    private String description;
    private Double price;
    private int stockQuantity;
    private Long categoryId;
    private List<String> imageUrls;
}
