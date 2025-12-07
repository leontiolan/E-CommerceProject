package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.Category;
import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Entity.ProductImage;
import com.example.E_CommerceSCD.Entity.Review;
import com.example.E_CommerceSCD.Repositories.CategoryRepository;
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import jakarta.persistence.criteria.Predicate;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
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

    private final String BASE_IMAGE_URL = "http://localhost:8083/images/";

    public Page<ProductSummaryDTO> searchProducts(String search, String sort, Long categoryId, Double minPrice, Double maxPrice, Pageable pageable) {
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

            if (minPrice != null) {
                predicates.add(criteriaBuilder.greaterThanOrEqualTo(root.get("price"), minPrice));
            }
            if (maxPrice != null) {
                predicates.add(criteriaBuilder.lessThanOrEqualTo(root.get("price"), maxPrice));
            }

            return criteriaBuilder.and(predicates.toArray(new Predicate[0]));
        };

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

    public ProductDetailDTO createProduct(ProductCreateUpdateDTO dto) {
        Category category = categoryRepository.findById(dto.getCategoryId())
                .orElseThrow(() -> new RuntimeException("Category not found"));

        Product product = new Product();
        product.setName(dto.getName());
        product.setDescription(dto.getDescription());
        product.setPrice(dto.getPrice());
        product.setStockQuantity(dto.getStockQuantity());
        product.setCategory(category);

        if (dto.getImageUrls() != null && !dto.getImageUrls().isEmpty()) {
            List<ProductImage> images = dto.getImageUrls().stream()
                    .map(url -> ProductImage.builder()
                            .imageUrl(url)
                            .product(product) // Link back to parent
                            .build())
                    .collect(Collectors.toList());
            product.setImages(images);
        }

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

        if (dto.getImageUrls() != null) {
            product.getImages().clear();

            List<ProductImage> newImages = dto.getImageUrls().stream()
                    .map(url -> ProductImage.builder()
                            .imageUrl(url)
                            .product(product)
                            .build())
                    .collect(Collectors.toList());

            product.getImages().addAll(newImages);
        }

        return mapToDetailDTO(productRepository.save(product));
    }

    public void deleteProduct(Long id) {
        productRepository.deleteById(id);
    }

    private ProductSummaryDTO mapToSummaryDTO(Product p) {
        String imageUrl = null;
        if (p.getImages() != null && !p.getImages().isEmpty()) {
            String rawUrl = p.getImages().get(0).getImageUrl();
            if (rawUrl != null && !rawUrl.startsWith("http")) {
                imageUrl = BASE_IMAGE_URL + rawUrl;
            } else {
                imageUrl = rawUrl;
            }
        }

        return ProductSummaryDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .price(p.getPrice())
                .imageUrl(imageUrl)
                .build();
    }

    private ProductDetailDTO mapToDetailDTO(Product p) {
        List<String> imageUrls = (p.getImages() != null)
                ? p.getImages().stream()
                .map(img -> {
                    String url = img.getImageUrl();
                    if (url != null && !url.startsWith("http")) {
                        return BASE_IMAGE_URL + url;
                    }
                    return url;
                })
                .collect(Collectors.toList())
                : new ArrayList<>();

        double avg = 0.0;
        if (p.getReviewList() != null && !p.getReviewList().isEmpty()) {
            double sum = p.getReviewList().stream().mapToInt(Review::getRating).sum();
            avg = sum / p.getReviewList().size();
        }
        double roundedAvg = Math.round(avg * 10.0) / 10.0;

        return ProductDetailDTO.builder()
                .id(p.getId())
                .name(p.getName())
                .description(p.getDescription())
                .price(p.getPrice())
                .stockQuantity(p.getStockQuantity())
                .averageRating(roundedAvg)
                .category(new CategoryDTO(p.getCategory().getId(), p.getCategory().getName()))
                .reviewDTOList(Collections.emptyList())
                .imageURLs(imageUrls)
                .build();
    }
}