package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CategoryDTO;
import com.example.E_CommerceSCD.DTOs.ProductDetailDTO;
import com.example.E_CommerceSCD.DTOs.ProductSummaryDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import com.example.E_CommerceSCD.Services.CategoryService;
import com.example.E_CommerceSCD.Services.ProductService;
import com.example.E_CommerceSCD.Services.ReviewService;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
public class CatalogController {

    private final ProductService productService;
    private final CategoryService categoryService;
    private final ReviewService reviewService;

    @GetMapping("/products")
    public ResponseEntity<Page<ProductSummaryDTO>> getProducts(
            @RequestParam(required = false) String search,
            @RequestParam(required = false) String sort,
            @RequestParam(required = false) Long category,
            @RequestParam(required = false) Double minPrice,
            @RequestParam(required = false) Double maxPrice,
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "12") int size
    ) {
        // Default sort
        Sort sortOrder = Sort.by("name").ascending();

        // Handle sort options
        if (sort != null) {
            switch (sort.toLowerCase()) {
                case "price_asc":
                    sortOrder = Sort.by("price").ascending();
                    break;
                case "price_desc":
                    sortOrder = Sort.by("price").descending();
                    break;
                case "name_desc":
                    sortOrder = Sort.by("name").descending();
                    break;
                default:
                    sortOrder = Sort.by("name").ascending();
            }
        }

        Pageable pageable = PageRequest.of(page, size, sortOrder);

        return ResponseEntity.ok(productService.searchProducts(search, sort, category, minPrice, maxPrice, pageable));
    }

    @GetMapping("/products/{id}")
    public ResponseEntity<ProductDetailDTO> getProductById(@PathVariable Long id) {
        return ResponseEntity.ok(productService.getProductDetails(id));
    }

    @GetMapping("/categories")
    public ResponseEntity<List<CategoryDTO>> getAllCategories() {
        return ResponseEntity.ok(categoryService.getAllCategories());
    }

    @GetMapping("/products/{id}/reviews")
    public ResponseEntity<List<ReviewDTO>> getReviewsForProduct(@PathVariable Long id) {
        return ResponseEntity.ok(reviewService.getReviewsForProduct(id));
    }
}