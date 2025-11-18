package com.example.E_CommerceSCD.Repositories;

import com.example.E_CommerceSCD.Entity.OrderItem;
import org.springframework.data.jpa.repository.JpaRepository;

public interface OrderItemRepository extends JpaRepository<OrderItem, Long> {
}
