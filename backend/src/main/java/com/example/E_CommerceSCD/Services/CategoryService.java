package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.CategoryCreateUpdateDTO;
import com.example.E_CommerceSCD.DTOs.CategoryDTO;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class CategoryService {

    public List<CategoryDTO> getAllCategories() {
        return List.of(
                CategoryDTO.builder().id(1L).name("Electronics").build(),
                CategoryDTO.builder().id(2L).name("Books").build()
        );
    }

    public CategoryDTO createCategory(CategoryCreateUpdateDTO dto) {
        return CategoryDTO.builder().id(5L).name(dto.getName()).build();
    }

    public CategoryDTO updateCategory(Long id, CategoryCreateUpdateDTO dto) {
        return CategoryDTO.builder().id(id).name(dto.getName()).build();
    }

    public void deleteCategory(Long id) {}
}