package com.thanhcomestic.beautysc.controller;

import java.util.Map;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.thanhcomestic.beautysc.dto.response.ApiResponse;

import jakarta.persistence.EntityManager;

@RestController
@RequestMapping("/health")
public class HealthController {
    
    private final EntityManager entityManager;

    public HealthController(EntityManager entityManager) {
        this.entityManager = entityManager;
    }
    
    @GetMapping("/db")
    public ApiResponse<Map<String, Object>> db() {
        Object now = entityManager.createNativeQuery("SELECT NOW()").getSingleResult();
        Object db = entityManager.createNativeQuery("SELECT DATABASE()").getSingleResult();
        return ApiResponse.ok(Map.of("now", now, "db", db));
    }
}