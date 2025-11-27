package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CheckoutRequestDTO;
import com.example.E_CommerceSCD.DTOs.OrderSummaryDTO;
import com.example.E_CommerceSCD.Services.OrderService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/orders")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('USER')")
public class OrderController {

    private final OrderService orderService;

    @PostMapping("/checkout")
    public ResponseEntity<OrderSummaryDTO> checkout(
            @RequestBody CheckoutRequestDTO checkoutRequest
    ) {
        return ResponseEntity.ok(orderService.placeOrder(checkoutRequest));
    }

    @GetMapping("/my-orders")
    public ResponseEntity<List<OrderSummaryDTO>> getMyOrderHistory() {
        return ResponseEntity.ok(orderService.getOrderHistoryForCurrentUser());
    }

    // --- NEW: Cancel Endpoint ---
    @PutMapping("/{id}/cancel")
    public ResponseEntity<Void> cancelOrder(@PathVariable Long id) {
        orderService.cancelMyOrder(id);
        return ResponseEntity.ok().build();
    }
}