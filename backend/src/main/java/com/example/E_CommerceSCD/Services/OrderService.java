package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.*;
import org.springframework.stereotype.Service;
import java.time.LocalDate;
import java.util.List;

@Service
public class OrderService {

    public OrderSummaryDTO placeOrder(CheckoutRequestDTO request) {
        return OrderSummaryDTO.builder()
                .id(500L).status("PENDING").orderDate(LocalDate.now()).orderPrice(150.0).build();
    }

    public List<OrderSummaryDTO> getOrderHistoryForCurrentUser() {
        return List.of(
                OrderSummaryDTO.builder().id(500L).status("SHIPPED").build()
        );
    }

    public List<OrderSummaryDTO> getAllOrders() {
        return getOrderHistoryForCurrentUser();
    }

    public OrderSummaryDTO updateOrderStatus(Long id, OrderStatusUpdateDTO dto) {
        return OrderSummaryDTO.builder().id(id).status(dto.getStatus()).build();
    }
}