import type { StoreGet, StoreSet } from "../store";
import type { Voucher } from "../types/voucher";
import { apiClient, apiEndpoints } from "./utils.api";

export interface VouchersState {
  vouchers: Voucher[];
}

export interface VoucherActions {
  fetchAllVouchers: () => Promise<void>;
  getVoucherById: (voucherId: number) => Voucher | null;
  fetchAllVouchersByCustomerId: (customerId: number) => Promise<void>;
  createVoucher: (voucherData: Omit<Voucher, "voucherId">) => Promise<void>;
  updateVoucher: (voucherId: number, voucherData: Omit<Voucher, "voucherId">) => Promise<void>;
}

export const initialVoucher: VouchersState = {
  vouchers: [],
};

export function voucherActions(set: StoreSet, get: StoreGet): VoucherActions {
  return {
    // lấy tất cả voucher
    fetchAllVouchers: async () => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const response = await apiClient.get(
          `${apiEndpoints.Voucher}/get-all-vouchers`
        );

        set((state) => {
          state.voucher.vouchers = response.data?.$values || [];
        });
      } catch (error) {
        console.error("Error fetching vouchers:", error);
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },

    // tìm voucher trong store
    getVoucherById: (voucherId: number) => {
      const { vouchers } = get().voucher;
      return vouchers.find((v) => v.voucherId === voucherId) || null;
    },

    // lấy voucher theo customer
    fetchAllVouchersByCustomerId: async (customerId: number) => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const response = await apiClient.get(
          `${apiEndpoints.Voucher}/get-vouchers-by-customer-id/${customerId}`
        );

        set((state) => {
          state.voucher.vouchers = response.data?.$values || [];
        });
      } catch (error) {
        console.error("Error fetching vouchers by customer ID:", error);
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },

    // tạo voucher
    createVoucher: async (voucherData) => {
      try {
        await apiClient.post(
          `${apiEndpoints.Voucher}/create-voucher`,
          voucherData
        );

        await get().fetchAllVouchers();
      } catch (error) {
        console.error("Error creating voucher:", error);
      }
    },

    // update voucher
    updateVoucher: async (voucherId, voucherData) => {
      try {
        await apiClient.put(
          `${apiEndpoints.Voucher}/update-voucher/${voucherId}`,
          voucherData
        );

        await get().fetchAllVouchers();
      } catch (error) {
        console.error("Error updating voucher:", error);
      }
    },
  };
}