package com.thanhcomestic.beautysc.entity.enums;

public enum Role {
    MANAGER,
    STAFF,
    CUSTOMER;

    public static Role fromDb(String dbValue) {
        return Role.valueOf(dbValue.toUpperCase());
    }

    public String toAuthority() {
        return "ROLE_" + this.name();
    }
}