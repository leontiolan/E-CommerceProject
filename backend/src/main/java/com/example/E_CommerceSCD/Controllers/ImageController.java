package com.example.E_CommerceSCD.Controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.UUID;

@RestController
@RequestMapping("/api/admin/images")
@CrossOrigin(origins = "*")
public class ImageController {

    @PostMapping("/upload")
    public ResponseEntity<String> uploadImage(@RequestParam("file") MultipartFile file) {
        if (file.isEmpty()) {
            return ResponseEntity.badRequest().body("File is empty");
        }

        try {
            // 1. Ensure directory exists relative to the backend execution
            Path uploadDir = Paths.get("product-images");
            if (!Files.exists(uploadDir)) {
                Files.createDirectories(uploadDir);
            }

            // 2. Generate unique filename to avoid conflicts
            String originalFilename = file.getOriginalFilename();
            String extension = "";
            if (originalFilename != null && originalFilename.contains(".")) {
                extension = originalFilename.substring(originalFilename.lastIndexOf("."));
            } else {
                extension = ".jpg"; // Default if no extension found
            }

            String newFilename = UUID.randomUUID().toString() + extension;

            // 3. Save file
            Path filePath = uploadDir.resolve(newFilename);
            Files.copy(file.getInputStream(), filePath);

            // 4. Return just the filename.
            // The ProductService already knows how to append "http://localhost:8083/images/" to these names.
            return ResponseEntity.ok(newFilename);

        } catch (IOException e) {
            e.printStackTrace();
            return ResponseEntity.internalServerError().body("Failed to upload image: " + e.getMessage());
        }
    }
}