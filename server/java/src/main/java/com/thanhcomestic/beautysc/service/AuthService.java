package com.thanhcomestic.beautysc.service;

import com.thanhcomestic.beautysc.dto.request.LoginRequest;
import com.thanhcomestic.beautysc.dto.response.AuthResponse;

public interface AuthService {
    AuthResponse login(LoginRequest request);
}
