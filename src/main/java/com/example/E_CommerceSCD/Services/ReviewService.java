package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.CreateReviewDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class ReviewService {

    public List<ReviewDTO> getReviewsForProduct(Long id) {
        return List.of(
                ReviewDTO.builder().id(1L).username("testuser").rating(5).comment("Great!").build()
        );
    }

    public ReviewDTO createReview(CreateReviewDTO dto) {
        return ReviewDTO.builder().id(1L).rating(dto.getRating()).comment(dto.getComment()).build();
    }
}