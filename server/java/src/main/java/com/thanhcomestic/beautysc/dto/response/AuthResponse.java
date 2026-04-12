package com.thanhcomestic.beautysc.dto.response;

import lombok.AllArgsConstructor;
import lombok.Getter;

@Getter
@AllArgsConstructor
public class AuthResponse {
    private String tokenType; // Bearer
    private String accessToken; // JWT
    private String role;
}
