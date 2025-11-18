package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CategoryDTO;
import com.example.E_CommerceSCD.DTOs.ProductDetailDTO;
import com.example.E_CommerceSCD.DTOs.ProductSummaryDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import com.example.E_CommerceSCD.Services.CategoryService;
import com.example.E_CommerceSCD.Services.ProductService;
import com.example.E_CommerceSCD.Services.ReviewService;
import lombok.RequiredArgsConstructor;
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
    public ResponseEntity<List<ProductSummaryDTO>> getProducts(
            @RequestParam(required = false) String search,
            @RequestParam(required = false) String sort,
            @RequestParam(required = false) Long category
    ) {
        return ResponseEntity.ok(productService.searchProducts(search, sort, category));
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
