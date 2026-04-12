package com.thanhcomestic.beautysc.service.impl;

import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import com.thanhcomestic.beautysc.dto.request.LoginRequest;
import com.thanhcomestic.beautysc.dto.response.AuthResponse;
import com.thanhcomestic.beautysc.entity.enums.Account;
import com.thanhcomestic.beautysc.exception.BadRequestException;
import com.thanhcomestic.beautysc.repository.AccountRepository;
import com.thanhcomestic.beautysc.security.JwtTokenProvider;
import com.thanhcomestic.beautysc.service.AuthService;

@Service
public class AuthServiceImpl implements AuthService {
    private final AccountRepository accountRepository;
    private final PasswordEncoder passwordEncoder;
    private final JwtTokenProvider jwtTokenProvider;

    public AuthServiceImpl(AccountRepository accountRepository, PasswordEncoder passwordEncoder,
            JwtTokenProvider jwtTokenProvider) {
        this.accountRepository = accountRepository;
        this.passwordEncoder = passwordEncoder;
        this.jwtTokenProvider = jwtTokenProvider;
    }

    @Override
    public AuthResponse login(LoginRequest req) {
        Account acc = accountRepository.findByEmail(req.getEmail())
                .orElseThrow(() -> new BadRequestException("Invalid email or password"));
        if (!passwordEncoder.matches(req.getPassword(), acc.getPassword())) {
            throw new BadRequestException("Invalid email or password");
        }
        String roleUpper = (acc.getRole().toUpperCase() == null) ? "CUSTOMER" : acc.getRole().toUpperCase();
        String token = jwtTokenProvider.generateAccessToken(acc.getEmail(), roleUpper);
        return new AuthResponse("Bearer", token, roleUpper);
    }
}
