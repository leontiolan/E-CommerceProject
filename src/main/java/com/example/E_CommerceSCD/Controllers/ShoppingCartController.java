package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CartAddItemDTO;
import com.example.E_CommerceSCD.DTOs.CartUpdateQuantityDTO;
import com.example.E_CommerceSCD.DTOs.ShoppingCartDTO;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/cart")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('USER')")
public class ShoppingCartController {

    private final CartService cartService;

    @GetMapping
    public ResponseEntity<ShoppingCartDTO> getCart() {
        return ResponseEntity.ok(cartService.getCartForCurrentUser());
    }

    @PostMapping("/items")
    public ResponseEntity<ShoppingCartDTO> addItemToCart(
            @RequestBody CartAddItemDTO itemDto
    ) {
        return ResponseEntity.ok(cartService.addItemToCart(itemDto));
    }

    @PutMapping("/items/{cartItemId}")
    public ResponseEntity<ShoppingCartResponseDto> updateItemQuantity(
            @PathVariable Long cartItemId,
            @RequestBody CartUpdateQuantityDTO updateDto
    ) {
        return ResponseEntity.ok(cartService.updateItemQuantity(cartItemId, updateDto));
    }

    @DeleteMapping("/items/{cartItemId}")
    public ResponseEntity<ShoppingCartDTO> removeItemFromCart(
            @PathVariable Long cartItemId
    ) {
        return ResponseEntity.ok(cartService.removeItemFromCart(cartItemId));
    }
}