package com.thanhcomestic.beautysc.security;

import java.util.List;

import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.thanhcomestic.beautysc.entity.enums.Account;
import com.thanhcomestic.beautysc.repository.AccountRepository;

@Service
public class CustomerUserDetailsService implements UserDetailsService {
    private final AccountRepository accountRepository;

    public CustomerUserDetailsService(AccountRepository accountRepository) {
        this.accountRepository = accountRepository;
    }

    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
        Account acc = accountRepository.findByEmail(email)
                .orElseThrow(() -> new UsernameNotFoundException("User not found with email: " + email));
        String roleUpper = (acc.getRole().toUpperCase() == null) ? "CUSTOMER" : acc.getRole().toUpperCase();
        return new User(acc.getEmail(), acc.getPassword(), List.of(new SimpleGrantedAuthority("ROLE_" + roleUpper)));
    }
}
