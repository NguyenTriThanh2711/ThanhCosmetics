package com.thanhcomestic.beautysc.repository;

import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import com.thanhcomestic.beautysc.entity.enums.Account;

public interface AccountRepository extends JpaRepository<Account, Integer> {
    Optional<Account> findByEmail(String email);
}
