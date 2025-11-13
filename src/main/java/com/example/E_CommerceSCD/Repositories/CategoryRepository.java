package com.example.E_CommerceSCD.Repositories;

import com.example.E_CommerceSCD.Entity.Category;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, Long> {
}
