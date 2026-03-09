import type { StoreGet, StoreSet } from "../store";
import { apiClient, apiEndpoints } from "./utils.api";

export interface PaymentState {
  paymentUrl: string | null;
}

export interface PaymentActions {
  createPayment: (orderId: number, token: string) => Promise<string>;
  rePayment: (orderId: number, token: string) => Promise<string>;
}

export const initialPayment: PaymentState = {
  paymentUrl: null,
};

export function paymentActions(set: StoreSet, get: StoreGet): PaymentActions {
  return {
    // tạo payment
    createPayment: async (orderId: number, token: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const response = await apiClient.post(
          `${apiEndpoints.Payment}/payment?orderId=${orderId}`,
          {},
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const paymentUrl = response.data;

        set((state) => {
          state.payment.paymentUrl = paymentUrl;
        });

        return paymentUrl;
      } catch (error) {
        console.error("Error creating payment:", error);
        throw error;
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },

    // thanh toán lại
    rePayment: async (orderId: number, token: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const response = await apiClient.post(
          `${apiEndpoints.Payment}/payment?orderId=${orderId}`,
          {},
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const paymentUrl = response.data;

        set((state) => {
          state.payment.paymentUrl = paymentUrl;
        });

        return paymentUrl;
      } catch (error) {
        console.error("Error in rePayment:", error);
        throw error;
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
  };
}