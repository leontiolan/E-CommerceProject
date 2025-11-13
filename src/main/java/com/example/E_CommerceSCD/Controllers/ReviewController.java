package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CreateReviewDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/reviews")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('USER')") // Only users can write reviews
public class ReviewController {

    private final ReviewService reviewService;

    @PostMapping
    public ResponseEntity<ReviewDTO> postReview(
            @RequestBody CreateReviewDTO reviewCreateDto
    ) {
        return ResponseEntity.ok(reviewService.createReview(reviewCreateDto));
    }
}
