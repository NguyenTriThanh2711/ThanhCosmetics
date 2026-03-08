import type { StoreGet, StoreSet } from "../store";
import { type Order, type OrderCategory, type OrderDetail, type PurchaseDetail, type SkinTypeWrapper } from "../types/order";
import { apiClient, apiEndpoints } from "./utils.api";

export interface OrderState {
  orders: Order[];
  purchaseDetails: PurchaseDetail | null;
}
export interface OrderActions {
  fetchUserOrders: () => Promise<void>;
  fetchPurchaseDetails: (orderId: number) => Promise<void>;
}

export const initialOrder: OrderState = {
  orders: [],
  purchaseDetails: null,
};

const mapApiToOrderDetail = (apiDetail: any): OrderDetail => {
  return {
    orderDetailId: apiDetail.orderDetailId,
    productId: apiDetail.productId,
    productName: apiDetail.productName,
    size: apiDetail.size,
    quantity: apiDetail.quantity,
    price: apiDetail.price,
    discount: apiDetail.discount,
    productImage:
      apiDetail.productImage || "https://via.placeholder.com/100",
    category: {
      categoryId: apiDetail.category?.categoryId || 0,
      categoryName: apiDetail.category?.categoryName || "Unknown",
    } as OrderCategory,
    skinTypes: {
      $id: apiDetail.skinTypes?.$id || "",
      $values: apiDetail.skinTypes?.$values || [],
    } as SkinTypeWrapper,
  };
};

const mapApiToOrder = (apiOrder: any): Order => {
  return {
    orderId: apiOrder.orderId,
    orderCode: apiOrder.orderCode,
    fullName: apiOrder.fullName || "Unknown",
    address: apiOrder.address,
    shippingPrice: apiOrder.shippingPrice,
    voucher: apiOrder.voucher || "None",
    phoneNumber: apiOrder.phoneNumber,
    totalAmount: apiOrder.totalAmount,
    paymentMethodName: apiOrder.paymentMethodName || "N/A",
    status: apiOrder.status,
    createdDate: apiOrder.createdDate,
    details:
      apiOrder.details?.$values?.map((detail: any) =>
        mapApiToOrderDetail(detail)
      ) || [],
  };
};

const mapApiToPurchaseDetail = (apiData: any): PurchaseDetail => {
  return {
    $id: apiData.$id,
    orderId: apiData.orderId,
    orderCode: apiData.orderCode,
    fullName: apiData.fullName,
    address: apiData.address,
    shippingPrice: apiData.shippingPrice,
    paymentMethodName: apiData.paymentMethodName,
    voucher: apiData.voucher,
    phoneNumber: apiData.phoneNumber,
    totalAmount: apiData.totalAmount,
    status: apiData.status,
    createdDate: apiData.createdDate,
    details: {
      $id: apiData.details?.$id || "",
      $values: apiData.details?.$values || [],
    },
  };
};

export function orderActions(set: StoreSet, get: StoreGet): OrderActions {
  return {
    fetchUserOrders: async (status?: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const url =
          status && status !== ""
            ? `${apiEndpoints.Orders}/get-user-order?status=${status}`
            : `${apiEndpoints.Orders}/get-user-order`;

        const response = await apiClient.get(url);

        const ordersArray = response.data?.$values || [];

        const orders = ordersArray.map((order: any) =>
          mapApiToOrder(order)
        );

        set((state) => {
          state.brands = orders;
        });
      } catch (error: any) {
        set((state) => {
          state.notification.data.push({
            status: "ERROR",
            content: error?.message || "Failed to fetch orders",
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },

    fetchPurchaseDetail: async (orderId: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });

      try {
        const url = `${apiEndpoints.Order}/get_order_by_id?orderId=${orderId}`;

        const response = await apiClient.get(url);

        const detail = mapApiToPurchaseDetail(response.data);

        set((state) => {
          state.orders.purchaseDetail = detail;
        });
      } catch (error: any) {
        set((state) => {
          state.notification.data.push({
            status: "ERROR",
            content: error?.message || "Failed to fetch order detail",
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
  };
}