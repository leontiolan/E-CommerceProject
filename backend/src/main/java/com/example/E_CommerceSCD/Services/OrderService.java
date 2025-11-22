package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.*;
import com.example.E_CommerceSCD.Repositories.OrderRepository;
import com.example.E_CommerceSCD.Repositories.ShoppingCartRepository;
import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class OrderService {

    private final OrderRepository orderRepository;
    private final ShoppingCartRepository cartRepository;
    private final UserService userService;

    @Transactional
    public OrderSummaryDTO placeOrder(CheckoutRequestDTO request) {
        User user = userService.getCurrentUser();
        ShoppingCart cart = cartRepository.findByUserId(user.getId()).orElseThrow();

        if (cart.getCartItemList().isEmpty()) {
            throw new RuntimeException("Cart is empty");
        }

        double total = cart.getCartItemList().stream()
                .mapToDouble(item -> item.getProduct().getPrice() * item.getQuantity())
                .sum();

        Order order = Order.builder()
                .user(user)
                .orderDate(LocalDate.now())
                .status("PENDING")
                .shippingAddress(request.getShippingAdress())
                .orderPrice(total)
                .orderItemList(new ArrayList<>())
                .build();

        // Transfer items from Cart to Order
        List<OrderItem> orderItems = cart.getCartItemList().stream().map(cartItem -> {
            OrderItem orderItem = new OrderItem();
            orderItem.setOrder(order);
            orderItem.setProduct(cartItem.getProduct());
            orderItem.setQuantity(cartItem.getQuantity());
            orderItem.setPurchasePrice(cartItem.getProduct().getPrice());
            return orderItem;
        }).collect(Collectors.toList());

        order.setOrderItemList(orderItems);
        Order savedOrder = orderRepository.save(order);

        // Clear the cart
        cart.getCartItemList().clear();
        cartRepository.save(cart);

        return mapToDTO(savedOrder);
    }

    public List<OrderSummaryDTO> getOrderHistoryForCurrentUser() {
        User user = userService.getCurrentUser();
        return orderRepository.findByUserOrderByOrderDateDesc(user).stream()
                .map(this::mapToDTO)
                .collect(Collectors.toList());
    }

    public List<OrderSummaryDTO> getAllOrders() {
        return orderRepository.findAll().stream()
                .map(this::mapToDTO)
                .collect(Collectors.toList());
    }

    public OrderSummaryDTO updateOrderStatus(Long id, OrderStatusUpdateDTO dto) {
        Order order = orderRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Order not found"));
        order.setStatus(dto.getStatus());
        return mapToDTO(orderRepository.save(order));
    }

    private OrderSummaryDTO mapToDTO(Order order) {
        return OrderSummaryDTO.builder()
                .id(order.getId())
                .orderDate(order.getOrderDate())
                .status(order.getStatus())
                .orderPrice(order.getOrderPrice())
                .build();
    }
}