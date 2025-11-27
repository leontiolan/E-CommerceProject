package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.Category;
import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Entity.ProductImage;
import com.example.E_CommerceSCD.Repositories.CategoryRepository;
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import jakarta.persistence.criteria.Predicate;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable; // Important import
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

    // --- UPDATED: Search with Pagination ---
    public Page<ProductSummaryDTO> searchProducts(String search, String sort, Long categoryId, Pageable pageable) {
        Specification<Product> spec = (root, query, criteriaBuilder) -> {
            List<Predicate> predicates = new ArrayList<>();

            if (search != null && !search.isEmpty()) {
                predicates.add(criteriaBuilder.like(
                        criteriaBuilder.lower(root.get("name")),
                        "%" + search.toLowerCase() + "%"
                ));
            }

            if (categoryId != null) {
                predicates.add(criteriaBuilder.equal(root.get("category").get("id"), categoryId));
            }

            return criteriaBuilder.and(predicates.toArray(new Predicate[0]));
        };

        // Note: Sorting is now handled by the Pageable object passed from Controller
        Page<Product> products = productRepository.findAll(spec, pageable);

        return products.map(this::mapToSummaryDTO);
    }

    public ProductDetailDTO getProductDetails(Long id) {
        Product p = productRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Product not found"));
        return mapToDetailDTO(p);
    }

    public List<ProductDetailDTO> getAllProductsDetailed() {
        return productRepository.findAll().stream()
                .map(this::mapToDetailDTO)
                .collect(Collectors.toList());
    }

    // --- ADMIN METHODS (Unchanged except mapped DTOs) ---
    public ProductDetailDTO createProduct(ProductCreateUpdateDTO dto) {
        Category category = categoryRepository.findById(dto.getCategoryId())
                .orElseThrow(() -> new RuntimeException("Category not found"));

        Product product = new Product();
        product.setName(dto.getName());
        product.setDescription(dto.getDescription());
        product.setPrice(dto.getPrice());
        product.setStockQuantity(dto.getStockQuantity());
        product.setCategory(category);

        // Note: Image creation logic would go here if images were sent in DTO

        Product saved = productRepository.save(product);
        return mapToDetailDTO(saved);
    }

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

    public void deleteProduct(Long id) {
        productRepository.deleteById(id);
    }

    // --- MAPPERS ---

    private ProductSummaryDTO mapToSummaryDTO(Product p) {
        return ProductSummaryDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .price(p.getPrice())
                .build();
    }

    private ProductDetailDTO mapToDetailDTO(Product p) {
        // Map images
        List<String> imageUrls = (p.getImages() != null)
                ? p.getImages().stream().map(ProductImage::getImageUrl).collect(Collectors.toList())
                : new ArrayList<>();

        return ProductDetailDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .description(p.getDescription())
                .price(p.getPrice())
                .stockQuantity(p.getStockQuantity())
                .category(new CategoryDTO(p.getCategory().getId(), p.getCategory().getName()))
                .reviewDTOList(Collections.emptyList())
                .imageURLs(imageUrls) // Set images
                .build();
    }
}