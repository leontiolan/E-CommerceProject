package com.example.E_CommerceSCD.Services;

import com.example.E_CommerceSCD.DTOs.CreateReviewDTO;
import com.example.E_CommerceSCD.DTOs.ReviewDTO;
import com.example.E_CommerceSCD.Entity.Product;
import com.example.E_CommerceSCD.Entity.Review;
import com.example.E_CommerceSCD.Entity.User;
import com.example.E_CommerceSCD.Repositories.OrderRepository; // Added
import com.example.E_CommerceSCD.Repositories.ProductRepository;
import com.example.E_CommerceSCD.Repositories.ReviewRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class ReviewService {

    private final ReviewRepository reviewRepository;
    private final ProductRepository productRepository;
    private final UserService userService;
    private final OrderRepository orderRepository; // Injected

    public List<ReviewDTO> getReviewsForProduct(Long productId) {
        return reviewRepository.findByProductId(productId).stream()
                .map(r -> ReviewDTO.builder()
                        .id(r.getId())
                        .rating(r.getRating())
                        .comment(r.getComment())
                        .username(r.getUser().getUsername())
                        .build())
                .collect(Collectors.toList());
    }

    public ReviewDTO createReview(CreateReviewDTO dto) {
        User user = userService.getCurrentUser();
        Product product = productRepository.findById(dto.getProductId())
                .orElseThrow(() -> new RuntimeException("Product not found"));

        // --- NEW: Check Eligibility ---
        boolean hasDeliveredOrder = orderRepository.existsByUserIdAndOrderItemList_ProductIdAndStatus(
                user.getId(), dto.getProductId(), "DELIVERED");

        if (!hasDeliveredOrder) {
            throw new RuntimeException("You can only review products from orders that have been DELIVERED.");
        }
        // ------------------------------

        Review review = new Review();
        review.setRating(dto.getRating());
        review.setComment(dto.getComment());
        review.setProduct(product);
        review.setUser(user);

        Review saved = reviewRepository.save(review);

        return ReviewDTO.builder()
                .id(saved.getId())
                .rating(saved.getRating())
                .comment(saved.getComment())
                .username(user.getUsername())
                .build();
    }
}