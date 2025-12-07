package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.CartItem;
import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Entity.ShoppingCart;
import com.example.E_CommerceSCD.Entity.User;
import com.example.E_CommerceSCD.Repositories.CartItemRepository;
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import com.example.E_CommerceSCD.Repositories.ShoppingCartRepository;
import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class CartService {

    private final ShoppingCartRepository cartRepository;
    private final CartItemRepository cartItemRepository;
    private final ProductRepository productRepository;
    private final UserService userService;

    public ShoppingCartDTO getCartForCurrentUser() {
        User user = userService.getCurrentUser();
        ShoppingCart cart = cartRepository.findByUserId(user.getId())
                .orElseThrow(() -> new RuntimeException("Cart not found"));
        return mapToDTO(cart);
    }

    @Transactional
    public ShoppingCartDTO addItemToCart(CartAddItemDTO dto) {
        User user = userService.getCurrentUser();
        ShoppingCart cart = cartRepository.findByUserId(user.getId())
                .orElseThrow(() -> new RuntimeException("Cart not found"));

        Product product = productRepository.findById(dto.getProductId())
                .orElseThrow(() -> new RuntimeException("Product not found"));
        CartItem existingItem = cart.getCartItemList().stream()
                .filter(item -> item.getProduct().getId().equals(product.getId()))
                .findFirst().orElse(null);

        if (existingItem != null) {
            existingItem.setQuantity(existingItem.getQuantity() + dto.getQuantity());
        } else {
            CartItem newItem = CartItem.builder()
                    .cart(cart)
                    .product(product)
                    .quantity(dto.getQuantity())
                    .build();
            cart.getCartItemList().add(newItem);
        }

        ShoppingCart savedCart = cartRepository.save(cart);
        return mapToDTO(savedCart);
    }

    public ShoppingCartDTO updateItemQuantity(Long cartItemId, CartUpdateQuantityDTO dto) {
        CartItem item = cartItemRepository.findById(cartItemId)
                .orElseThrow(() -> new RuntimeException("Item not found"));

        item.setQuantity(dto.getQuantity());
        cartItemRepository.save(item);
        return getCartForCurrentUser();
    }

    public ShoppingCartDTO removeItemFromCart(Long cartItemId) {
        cartItemRepository.deleteById(cartItemId);
        return getCartForCurrentUser();
    }

    private ShoppingCartDTO mapToDTO(ShoppingCart cart) {
        if(cart.getCartItemList() == null) cart.setCartItemList(new ArrayList<>());

        double total = cart.getCartItemList().stream()
                .mapToDouble(item -> item.getProduct().getPrice() * item.getQuantity())
                .sum();

        List<CartItemDetailsDTO> itemDTOs = cart.getCartItemList().stream()
                .map(item -> CartItemDetailsDTO.builder()
                        .cartItemId(item.getId())
                        .productId(item.getProduct().getId())
                        .productName(item.getProduct().getName())
                        .productPrice(item.getProduct().getPrice())
                        .quantity(item.getQuantity())
                        .build())
                .collect(Collectors.toList());

        return ShoppingCartDTO.builder()
                .id(cart.getId())
                .cartItemDetailsDTOList(itemDTOs)
                .totalCartPrice(total)
                .build();
    }
}