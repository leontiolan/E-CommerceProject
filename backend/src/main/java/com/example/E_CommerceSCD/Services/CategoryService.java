package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.CategoryCreateUpdateDTO;
import com.example.E_CommerceSCD.DTOs.CategoryDTO;
import com.example.E_CommerceSCD.Entity.Category;
import com.example.E_CommerceSCD.Repositories.CategoryRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class CategoryService {

    private final CategoryRepository categoryRepository;

    public List<CategoryDTO> getAllCategories() {
        return categoryRepository.findAll().stream()
                .map(cat -> CategoryDTO.builder()
                        .id(cat.getId())
                        .name(cat.getName())
                        .build())
                .collect(Collectors.toList());
    }

    public CategoryDTO createCategory(CategoryCreateUpdateDTO dto) {
        Category category = new Category();
        category.setName(dto.getName());
        Category saved = categoryRepository.save(category);
        return new CategoryDTO(saved.getId(), saved.getName());
    }

    public CategoryDTO updateCategory(Long id, CategoryCreateUpdateDTO dto) {
        Category category = categoryRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Category not found"));
        category.setName(dto.getName());
        Category saved = categoryRepository.save(category);
        return new CategoryDTO(saved.getId(), saved.getName());
    }

    public void deleteCategory(Long id) {
        categoryRepository.deleteById(id);
    }
}