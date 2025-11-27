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
public class ProductDetailDTO {
    private Long id;
    private String name;
    private Double price;
    private String description;
    private int stockQuantity;
    private CategoryDTO category;
    private List<ReviewDTO> reviewDTOList;
    private List<String> imageURLs;
}
