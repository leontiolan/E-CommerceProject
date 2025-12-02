package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import com.example.E_CommerceSCD.Entity.*;
import com.example.E_CommerceSCD.Repositories.OrderRepository;
import com.example.E_CommerceSCD.Repositories.ProductRepository; // Added
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
    private final ProductRepository productRepository; // Need this to save product stock

    @Transactional
    public OrderSummaryDTO placeOrder(CheckoutRequestDTO request) {
        User user = userService.getCurrentUser();
        ShoppingCart cart = cartRepository.findByUserId(user.getId()).orElseThrow();

        if (cart.getCartItemList().isEmpty()) {
            throw new RuntimeException("Cart is empty");
        }

        // Calculate total first
        double total = cart.getCartItemList().stream()
                .mapToDouble(item -> item.getProduct().getPrice() * item.getQuantity())
                .sum();

        Order order = Order.builder()
                .user(user)
                .orderDate(LocalDate.now())
                .status("PENDING")
                .shippingAddress(request.getShippingAddress())
                .orderPrice(total)
                .orderItemList(new ArrayList<>())
                .build();

        // Transfer items & REDUCE STOCK
        List<OrderItem> orderItems = cart.getCartItemList().stream().map(cartItem -> {
            Product product = cartItem.getProduct();

            // --- 1. STOCK CHECK ---
            if (product.getStockQuantity() < cartItem.getQuantity()) {
                throw new RuntimeException("Insufficient stock for product: " + product.getName());
            }
            // --- 2. STOCK REDUCTION ---
            product.setStockQuantity(product.getStockQuantity() - cartItem.getQuantity());
            // productRepository.save(product); // Optional if using @Transactional, but explicit is safe

            OrderItem orderItem = new OrderItem();
            orderItem.setOrder(order);
            orderItem.setProduct(product);
            orderItem.setQuantity(cartItem.getQuantity());
            orderItem.setPurchasePrice(product.getPrice());
            return orderItem;
        }).collect(Collectors.toList());

        order.setOrderItemList(orderItems);
        Order savedOrder = orderRepository.save(order);

        // Clear cart
        cart.getCartItemList().clear();
        cartRepository.save(cart);

        return mapToDTO(savedOrder);
    }

    // --- NEW: Cancel Order Logic ---
    @Transactional
    public void cancelMyOrder(Long orderId) {
        User user = userService.getCurrentUser();
        Order order = orderRepository.findById(orderId)
                .orElseThrow(() -> new RuntimeException("Order not found"));

        // Security
        if (!order.getUser().getId().equals(user.getId())) {
            throw new RuntimeException("Access Denied: You can only cancel your own orders.");
        }

        // Workflow Check
        if ("SHIPPED".equalsIgnoreCase(order.getStatus()) || "DELIVERED".equalsIgnoreCase(order.getStatus())) {
            throw new RuntimeException("Cannot cancel an order that has already been shipped or delivered.");
        }

        order.setStatus("CANCELLED");

        // Restore Stock
        for (OrderItem item : order.getOrderItemList()) {
            Product p = item.getProduct();
            p.setStockQuantity(p.getStockQuantity() + item.getQuantity());
            productRepository.save(p);
        }
        orderRepository.save(order);
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

    // --- UPDATED: Status Workflow ---
    public OrderSummaryDTO updateOrderStatus(Long id, OrderStatusUpdateDTO dto) {
        Order order = orderRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Order not found"));

        String oldStatus = order.getStatus();
        String newStatus = dto.getStatus();

        // Prevent invalid transitions
        if (("SHIPPED".equalsIgnoreCase(oldStatus) && "PENDING".equalsIgnoreCase(newStatus)) ||
                ("DELIVERED".equalsIgnoreCase(oldStatus))) {
            throw new RuntimeException("Invalid status transition from " + oldStatus + " to " + newStatus);
        }

        order.setStatus(newStatus);
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

    public OrderDetailDTO getOrderDetails(Long id) {
        Order order = orderRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Order not found"));

        List<OrderItemDTO> items = order.getOrderItemList().stream()
                .map(item -> OrderItemDTO.builder()
                        .productName(item.getProduct().getName())
                        .quantity(item.getQuantity())
                        .purchasePrice(item.getPurchasePrice())
                        .build())
                .collect(Collectors.toList());

        return OrderDetailDTO.builder()
                .id(order.getId())
                .orderDate(order.getOrderDate())
                .status(order.getStatus())
                .orderPrice(order.getOrderPrice())
                .shippingAddress(order.getShippingAddress())
                .orderItems(items)
                .build();
    }

    public OrderSummaryDTO markOrderAsDelivered(Long orderId) {
        User user = userService.getCurrentUser();
        Order order = orderRepository.findById(orderId)
                .orElseThrow(() -> new RuntimeException("Order not found"));

        if (!order.getUser().getId().equals(user.getId())) {
            throw new RuntimeException("Access Denied");
        }

        if (!"SHIPPED".equals(order.getStatus())) {
            throw new RuntimeException("You can only confirm delivery for shipped orders.");
        }

        order.setStatus("DELIVERED");
        return mapToDTO(orderRepository.save(order));
    }
}