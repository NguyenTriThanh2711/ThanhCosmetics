# BeautySC BE (Java Spring Boot)

Backend server viết bằng **Java Spring Boot** cho hệ thống BeautySC, sử dụng **MySQL**.

## Tech Stack
- Java (khuyến nghị JDK 17)
- Spring Boot (Web)
- Spring Data JPA
- MySQL 8 (chạy bằng Docker)
- Maven

---

## Yêu cầu môi trường
- Windows 10/11
- Docker Desktop
- JDK 17+
- Maven (hoặc dùng Maven wrapper nếu project có `mvnw`)

Kiểm tra nhanh:
```bash
java -version
mvn -v
docker -v
docker compose version
```
src/main/java/com/thanhcomestic/beautysc
├─ Application.java
├─ config/
│  ├─ OpenApiConfig.java
│  └─ WebConfig.java            
├─ controller/
│  ├─ HealthController.java
│  ├─ AuthController.java
│  ├─ AccountController.java
│  ├─ ProductController.java
│  └─ ... (module khác)
├─ dto/
│  ├─ request/
│  │  ├─ LoginRequest.java
│  │  ├─ RegisterRequest.java
│  │  └─ ...
│  └─ response/
│     ├─ ApiResponse.java
│     ├─ AuthResponse.java
│     └─ ...
├─ entity/
│  ├─ Account.java
│  ├─ RefreshToken.java             (phase 3)
│  ├─ Product.java
│  └─ enums/
│     └─ Role.java
├─ exception/
│  ├─ BadRequestException.java
│  ├─ NotFoundException.java
│  ├─ UnauthorizedException.java
│  └─ GlobalExceptionHandler.java
├─ mapper/
│  └─ (MapStruct/manual mapper)
├─ repository/
│  ├─ AccountRepository.java
│  ├─ RefreshTokenRepository.java   (phase 3)
│  └─ ...
├─ security/
│  ├─ SecurityConfig.java
│  ├─ JwtAuthenticationFilter.java
│  ├─ JwtTokenProvider.java
│  ├─ CustomUserDetailsService.java
│  └─ SecurityUtils.java            (lấy current user)
├─ service/
│  ├─ AuthService.java
│  ├─ AccountService.java
│  └─ impl/
│     ├─ AuthServiceImpl.java
│     ├─ AccountServiceImpl.java
│     └─ ...
└─ util/
   └─ PasswordUtil.java    
---
PHASE 0: 21/03 ---------9:46pm done
Phase 1: 22/03 ---------9:50pm start
Phase 2 06/04 (Auth) ---------8:10pm start
Phase 3 (Catalog)
Phase 4 ()
Phase 5 (Order) => đã bán hàng được.
