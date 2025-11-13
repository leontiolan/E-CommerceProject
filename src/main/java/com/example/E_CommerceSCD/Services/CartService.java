package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class CartService {

    public ShoppingCartDTO getCartForCurrentUser() {
        return ShoppingCartDTO.builder()
                .id(1L)
                .totalCartPrice(100.0)
                .cartItemDetailsDTOList(List.of(
                        CartItemDetailsDTO.builder().productName("Test Product").quantity(1).productPrice(100.0).build()
                ))
                .build();
    }

    public ShoppingCartDTO addItemToCart(CartAddItemDTO dto) {
        return getCartForCurrentUser(); // Just return the dummy cart
    }

    public ShoppingCartDTO updateItemQuantity(Long cartItemId, CartUpdateQuantityDTO dto) {
        return getCartForCurrentUser();
    }

    public ShoppingCartDTO removeItemFromCart(Long cartItemId) {
        return getCartForCurrentUser();
    }
}