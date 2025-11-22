package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.Category;
import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Repositories.CategoryRepository;
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import jakarta.persistence.criteria.Predicate;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class ProductService {

    private final ProductRepository productRepository;
    private final CategoryRepository categoryRepository;

    // --- CLIENT: Search, Sort, Filter ---
    public List<ProductSummaryDTO> searchProducts(String search, String sort, Long categoryId) {
        // 1. Build the Filter (Specification)
        Specification<Product> spec = (root, query, criteriaBuilder) -> {
            List<Predicate> predicates = new ArrayList<>();

            // Filter by Name (if search is provided)
            if (search != null && !search.isEmpty()) {
                predicates.add(criteriaBuilder.like(
                        criteriaBuilder.lower(root.get("name")),
                        "%" + search.toLowerCase() + "%"
                ));
            }

            // Filter by Category (if categoryId is provided)
            if (categoryId != null) {
                predicates.add(criteriaBuilder.equal(root.get("category").get("id"), categoryId));
            }

            return criteriaBuilder.and(predicates.toArray(new Predicate[0]));
        };

        // 2. Build the Sort
        Sort sortOrder = Sort.by("name").ascending(); // Default sort
        if (sort != null) {
            if (sort.equalsIgnoreCase("price_asc")) {
                sortOrder = Sort.by("price").ascending();
            } else if (sort.equalsIgnoreCase("price_desc")) {
                sortOrder = Sort.by("price").descending();
            }
        }

        // 3. Fetch Data from DB
        List<Product> products = productRepository.findAll(spec, sortOrder);

        // 4. Convert Entity -> DTO (The Missing Step!)
        return products.stream()
                .map(this::mapToSummaryDTO)
                .collect(Collectors.toList());
    }

    // --- CLIENT: View Single Product ---
    public ProductDetailDTO getProductDetails(Long id) {
        Product p = productRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Product not found"));

        return mapToDetailDTO(p);
    }

    // --- ADMIN: View All Products (Detailed) ---
    public List<ProductDetailDTO> getAllProductsDetailed() {
        return productRepository.findAll().stream()
                .map(this::mapToDetailDTO)
                .collect(Collectors.toList());
    }

    // --- ADMIN: Create Product ---
    public ProductDetailDTO createProduct(ProductCreateUpdateDTO dto) {
        Category category = categoryRepository.findById(dto.getCategoryId())
                .orElseThrow(() -> new RuntimeException("Category not found"));

        Product product = new Product();
        product.setName(dto.getName());
        product.setDescription(dto.getDescription());
        product.setPrice(dto.getPrice());
        product.setStockQuantity(dto.getStockQuantity());
        product.setCategory(category);

        Product saved = productRepository.save(product);
        return mapToDetailDTO(saved);
    }

    // --- ADMIN: Update Product ---
    public ProductDetailDTO updateProduct(Long id, ProductCreateUpdateDTO dto) {
        Product product = productRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Product not found"));

        Category category = categoryRepository.findById(dto.getCategoryId())
                .orElseThrow(() -> new RuntimeException("Category not found"));

        product.setName(dto.getName());
        product.setDescription(dto.getDescription());
        product.setPrice(dto.getPrice());
        product.setStockQuantity(dto.getStockQuantity());
        product.setCategory(category);

        return mapToDetailDTO(productRepository.save(product));
    }

    // --- ADMIN: Delete Product ---
    public void deleteProduct(Long id) {
        productRepository.deleteById(id);
    }

    // --- Helper Mappers (To keep code clean) ---

    private ProductSummaryDTO mapToSummaryDTO(Product p) {
        return ProductSummaryDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .price(p.getPrice())
                .build();
    }

    private ProductDetailDTO mapToDetailDTO(Product p) {
        return ProductDetailDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .description(p.getDescription())
                .price(p.getPrice())
                .stockQuantity(p.getStockQuantity())
                .category(new CategoryDTO(p.getCategory().getId(), p.getCategory().getName()))
                .reviewDTOList(Collections.emptyList()) // Keep empty to avoid recursion/performance issues
                .build();
    }
}