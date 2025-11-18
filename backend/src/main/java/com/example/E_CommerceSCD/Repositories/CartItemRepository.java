package com.example.E_CommerceSCD.Repositories;

import com.example.E_CommerceSCD.Entity.CartItem;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CartItemRepository extends JpaRepository<CartItem, Long> {
}
