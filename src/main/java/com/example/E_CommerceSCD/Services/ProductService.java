package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Collections;

@Service
public class ProductService {

    public List<ProductSummaryDTO> searchProducts(String search, String sort, Long category) {
        return List.of(
                ProductSummaryDTO.builder().id(1L).name("Test Product").price(99.99).build()
        );
    }

    public ProductDetailDTO getProductDetails(Long id) {
        return ProductDetailDTO.builder()
                .id(id)
                .name("Test Product")
                .description("This is a placeholder product description.")
                .price(99.99)
                .stockQuantity(10)
                .category(CategoryDTO.builder().id(1L).name("Tech").build())
                .reviewDTOList(Collections.emptyList())
                .build();
    }

    public ProductDetailDTO createProduct(ProductCreateUpdateDTO dto) {
        return ProductDetailDTO.builder().id(100L).name(dto.getName()).build();
    }

    public ProductDetailDTO updateProduct(Long id, ProductCreateUpdateDTO dto) {
        return ProductDetailDTO.builder().id(id).name(dto.getName()).build();
    }

    public void deleteProduct(Long id) {
        // Do nothing for placeholder
    }
}