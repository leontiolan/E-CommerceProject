package com.example.E_CommerceSCD.Controllers;

import com.example.E_CommerceSCD.DTOs.CreateReviewDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import com.example.E_CommerceSCD.Services.ReviewService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/reviews")
@RequiredArgsConstructor
@CrossOrigin(origins = "*")
@PreAuthorize("hasRole('USER')")
public class ReviewController {

    private final ReviewService reviewService;

    @PostMapping
    public ResponseEntity<ReviewDTO> postReview(
            @RequestBody CreateReviewDTO reviewCreateDto
    ) {
        return ResponseEntity.ok(reviewService.createReview(reviewCreateDto));
    }
}
