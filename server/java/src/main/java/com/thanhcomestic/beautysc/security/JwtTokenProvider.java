package com.thanhcomestic.beautysc.security;

import java.time.Instant;

import javax.crypto.SecretKey;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.security.Keys;


@Component
public class JwtTokenProvider {
    private final SecretKey key;
    private final long accessTokenMinutes;

    public JwtTokenProvider (
        @Value("${app.jwt.secret}") String secret,
        @Value("${app.jwt.accessTokenMinutes}") long accessTokenMinutes
    ) {
        this.key = Keys.hmacShaKeyFor(secret.getBytes());
        this.accessTokenMinutes = accessTokenMinutes;
    }

    public String generateAccessToken(String email, String roleUppercase) {
        Instant now = Instant.now();
        Instant exp = now.plusSeconds(accessTokenMinutes*60);
        return Jwts.builder()
            .subject(email)
            .claim("role", roleUppercase)
            .issuedAt(java.util.Date.from(now))
            .expiration(java.util.Date.from(exp))
            .claim("role", roleUppercase)
            .signWith(key)
            .compact();
    }

    public String getEmail(String token){
        return Jwts.parser().verifyWith(key).build()
            .parseSignedClaims(token)
            .getPayload()
            .getSubject();
    }

    public boolean validate(String token){
        Jwts.parser().verifyWith(key).build().parseSignedClaims(token);
        return true;
    }
}
