import type ProductDetail from "../pages/product/ProductDetail";
import type { StoreGet, StoreSet } from "../store";
import { apiClient, apiEndpoints } from "./utils.api";
export interface Brand {
  $id: string;
  brandId: string;
  brandName: string;
  brandImage: string;
}

export interface Category {
  $id: string;
  categoryId: string;
  categoryName: string;
}

export interface SkinType {
  $id: string;
  skinTypeId: string;
  skinTypeName: string;
}
export interface Product {
  $id: string;
  productId: string;
  productName: string;
  summary: string;
  quantity: number;
  price: number;
  discount: number;
  rating: number;
  productImage: string;
  status: boolean; // true for active, false for inactive
  brand: Brand;
  category: Category;
  skinTypes: {
    $id: string;
    $values: SkinType[];
  };
}
export interface ProductsState {
  products: Product[];
  bestSellersProducts: Product[];
  newInProducts: Product[];
  productDetail: ProductDetail | null;
}

export interface ProductsActions {
  fetchProducts: () => Promise<void>;
  fetchProductDetail: (productId: string) => Promise<void>;
  fetchBestSellersProducts: () => Promise<void>;
  fetchNewInProducts: () => Promise<void>;
  createProduct: (data: any) => Promise<void>;
  updateProduct: (productId: string, data: any) => Promise<void>;
  activateProduct: (productId: string) => Promise<void>;
  deactivateProduct: (productId: string) => Promise<void>;
}
export const initialProducts: ProductsState = {
  products: [],
  bestSellersProducts: [],
  newInProducts: [],
  productDetail: null,
};

export function productsActions(set: StoreSet, get: StoreGet): ProductsActions {
  return {
    fetchBestSellersProducts: async () => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        const response = await apiClient.get(
          `${apiEndpoints.Product}/get-best-seller-product`
        );
        set((state) => {
          state.products.bestSellersProducts = response.data?.$values || [];
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    fetchNewInProducts: async () => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        const response = await apiClient.get(`${apiEndpoints.Product}/get-new-product`);
        console.log("New In Products:", response.data?.$values);
        set((state) => {
          state.products.newInProducts = response.data?.$values || [];
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    fetchProducts: async () => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        const response = await apiClient.post(`${apiEndpoints.Product}/get-all-product`, null,
          {
            params: {
              page: 1,
              pageSize: 999,
              sortColumn: "productId",
              sortOrder: "asc",
            },
          }
        );
        set((state) => {
          state.products.products = response.data?.$values || [];
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    fetchProductDetail: async (productId : string) => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        const response = await apiClient.get(`${apiEndpoints.Product}/get-product-detail`,
          {
            params: {
              productId,
            },
          }
        );
        set((state) => {
          state.products.productDetail = response.data;
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    createProduct: async (data: any) => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        await apiClient.post(`${apiEndpoints.Product}/create-product`, data);
        get().fetchProducts();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Product created successfully!",
          });
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    updateProduct: async (productId: string, data: any) => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        await apiClient.put(`${apiEndpoints.Product}/update-product`, data ,
          {
            params: {
              productId,  
            },
          }
        );
        get().fetchProducts();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Product updated successfully!",
          });
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    activateProduct: async (productId: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        await apiClient.put(`${apiEndpoints.Product}/activate-product`, null,
          {
            params: {
              productId,
            },
          }
        );
        get().fetchProducts();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Product activated successfully!",
          });
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        }); 
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    },
    deactivateProduct: async (productId: string) => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        await apiClient.put(`${apiEndpoints.Product}/inactive-product`, null, 
          {
            params: {
              productId,    
            },
          }
        );
        get().fetchProducts();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Product deactivated successfully!",
          });
        });
      } catch (error: any) {
        set((state) => {
          const message = error?.response?.data?.message || error?.message;
          state.notification.data.push({
            status: "ERROR",
            content: message,
          });
        });
      } finally {
        set((state) => {
          state.loading.isLoading = false;
        });
      }
    }
  };
}