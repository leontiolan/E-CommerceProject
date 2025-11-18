package com.example.E_CommerceSCD.Repositories;

import com.example.E_CommerceSCD.Entity.Order;
import com.example.E_CommerceSCD.Entity.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface OrderRepository extends JpaRepository<Order, Long> {
    List<Order> findByUserOrderByOrderDateDesc(User user);
}
