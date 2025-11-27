package com.example.E_CommerceSCD.Repositories;

import com.example.E_CommerceSCD.Entity.Order;
import com.example.E_CommerceSCD.Entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface OrderRepository extends JpaRepository<Order, Long> {
    List<Order> findByUserOrderByOrderDateDesc(User user);

    // --- NEW: Check if user bought product and order is DELIVERED ---
    @Query("SELECT CASE WHEN COUNT(o) > 0 THEN true ELSE false END FROM Order o " +
            "JOIN o.orderItemList oi " +
            "WHERE o.user.id = :userId AND oi.product.id = :productId AND o.status = :status")
    boolean existsByUserIdAndOrderItemList_ProductIdAndStatus(
            @Param("userId") Long userId,
            @Param("productId") Long productId,
            @Param("status") String status
    );
}