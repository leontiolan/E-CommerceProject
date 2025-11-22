package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.Services.CategoryService;
import com.example.E_CommerceSCD.Services.OrderService;
import com.example.E_CommerceSCD.Services.ProductService;
import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Services.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/admin")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('ADMIN')")
public class AdminController {

    private final ProductService productService;
    private final CategoryService categoryService;
    private final OrderService orderService;
    private final UserService userService;

    // --- Product CRUD ---
    // (createProduct, updateProduct, deleteProduct... routes are unchanged)
    @PostMapping("/products")
    public ResponseEntity<ProductDetailDTO> createProduct(
            @RequestBody ProductCreateUpdateDTO createDto
    ) {
        return ResponseEntity.ok(productService.createProduct(createDto));
    }

    @PutMapping("/products/{id}")
    public ResponseEntity<ProductDetailDTO> updateProduct(
            @PathVariable Long id,
            @RequestBody ProductCreateUpdateDTO updateDto
    ) {
        return ResponseEntity.ok(productService.updateProduct(id, updateDto));
    }

    @DeleteMapping("/products/{id}")
    public ResponseEntity<Void> deleteProduct(@PathVariable Long id) {
        productService.deleteProduct(id);
        return ResponseEntity.noContent().build();
    }

    @PostMapping("/categories")
    public ResponseEntity<CategoryDTO> createCategory(
            @RequestBody CategoryCreateUpdateDTO createDto
    ) {
        return ResponseEntity.ok(categoryService.createCategory(createDto));
    }

    @PutMapping("/categories/{id}")
    public ResponseEntity<CategoryDTO> updateCategory(
            @PathVariable Long id,
            @RequestBody CategoryCreateUpdateDTO updateDto
    ) {
        return ResponseEntity.ok(categoryService.updateCategory(id, updateDto));
    }

    @DeleteMapping("/categories/{id}")
    public ResponseEntity<Void> deleteCategory(@PathVariable Long id) {
        categoryService.deleteCategory(id);
        return ResponseEntity.noContent().build();
    }

    @GetMapping("/products")
    public ResponseEntity<List<ProductDetailDTO>> getAllProductsForAdmin() {
        return ResponseEntity.ok(productService.getAllProductsDetailed());
    }

    @GetMapping("/orders")
    public ResponseEntity<List<OrderSummaryDTO>> getAllOrders() {
        return ResponseEntity.ok(orderService.getAllOrders());
    }

    @PutMapping("/orders/{id}/status")
    public ResponseEntity<OrderSummaryDTO> updateOrderStatus(
            @PathVariable Long id,
            @RequestBody OrderStatusUpdateDTO statusDto
    ) {
        return ResponseEntity.ok(orderService.updateOrderStatus(id, statusDto));
    }

    @GetMapping("/users")
    public ResponseEntity<List<UserDTO>> getAllUsers() {
        return ResponseEntity.ok(userService.getAllUsers());
    }

    @GetMapping("/users/{id}")
    public ResponseEntity<UserDetailAdminDTO> getUserByIdForAdmin(@PathVariable Long id) {
        return ResponseEntity.ok(userService.getUserDetailsForAdmin(id));
    }
}