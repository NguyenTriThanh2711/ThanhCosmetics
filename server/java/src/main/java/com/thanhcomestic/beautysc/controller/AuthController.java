package com.thanhcomestic.beautysc.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.thanhcomestic.beautysc.dto.response.ApiResponse;
import com.thanhcomestic.beautysc.dto.response.AuthResponse;
import com.thanhcomestic.beautysc.service.AuthService;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;


@RestController
@RequestMapping("/api/auth")
public class AuthController {
    private final AuthService authService;
    public AuthController(AuthService authService) {
        this.authService = authService;
    }
    @PostMapping("/login")
    public ApiResponse<AuthResponse> login(@RequestBody com.thanhcomestic.beautysc.dto.request.LoginRequest request) {
        AuthResponse response = authService.login(request);
        return ApiResponse.ok(response);
    }
    
}
