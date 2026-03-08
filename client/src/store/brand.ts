import type { StoreGet, StoreSet } from "../store";
import { apiClient, apiEndpoints } from "./utils.api";

export interface Brand {
  brandId: string;
  brandName: string;
  brandImage: string;
}
export interface BrandsState {
  brands: Brand[];
}

export interface BrandsActions {
  fetchBrands: () => Promise<void>;
  getBrandLogo: (brandId: string) => Promise<string|null>;
  createBrand: (brandData: { brandName: string; logo?: File }) => Promise<void>;
  updateBrand: (brandId: string, brandData: { brandName?: string; logo?: File }) => Promise<void>;
  deleteBrand: (brandId: string) => Promise<void>;
}
export const initialBrands: BrandsState = {
  brands: [],
};

export function brandsActions(set: StoreSet, get: StoreGet): BrandsActions {
  return{
    fetchBrands: async () => {
      set((state) => {
        state.loading.isLoading = true;
      });
      try {
        const response = await apiClient.get(`${apiEndpoints.Brand}/get-brands`);
        const data = response.data;
        let brands: Brand[] = [];
        if (Array.isArray(data)) brands = data;
        else if (data?.$values) brands = data.$values;
        else if (data?.data) brands = data.data;
        
        set((state) => {
          state.brands.brands = brands;
        });
        } catch (error: any) {
          set((state) => {
            state.notification.data.push({
              status: "ERROR",
              content: error?.response?.data?.message || error?.message || "Failed to fetch brands",
            });
          });
        } finally {
          set((state) => {
            state.loading.isLoading = false;
          });   
        }
    },
    getBrandLogo: async (brandId) => {    
      try {
        const response = await apiClient.get(`${apiEndpoints.Brand}/get-brand-image/${brandId}`, { 
          responseType: 'blob',
        });
        const imageUrl = URL.createObjectURL(response.data);
        return imageUrl;
      } catch (error: any) {
        set((state) => {
          state.notification.data.push({
            status: "ERROR",
            content: error?.response?.data?.message || error?.message || "Failed to fetch brand logo",
          });
        });
        return null;
      }
    },
    createBrand: async (brandData : { brandName: string; logo?: File }) => {
      try {
        const formData = new FormData();
        formData.append('brandName', brandData.brandName);
        if (brandData.logo) {
          formData.append('logo', brandData.logo);
        }
        await apiClient.post(`${apiEndpoints.Brand}/create-brand`, formData, {
          headers: { 'Content-Type': 'multipart/form-data' },
        });
        await get().fetchBrands();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Brand created successfully!",
          });
        });
      } catch (error: any) {
        set((state) => {
          state.notification.data.push({
            status: "ERROR",
            content: error?.response?.data?.message || error?.message || "Failed to create brand",
          });
        });
      }
    },
    updateBrand: async (brandId: string, brandData: { brandName?: string; logo?: File }) => {
      try {
        const formData = new FormData();
        if (brandData.brandName) formData.append("brandName", brandData.brandName);
        if (brandData.logo) formData.append('logo', brandData.logo);
        await apiClient.put(`${apiEndpoints.Brand}/update-brand/${brandId}`, formData, {
          headers: { 'Content-Type': 'multipart/form-data' },
        });
        await get().fetchBrands();
        set((state) => {
          state.notification.data.push({
            status: "SUCCESS",
            content: "Brand updated successfully!",
          });
        });
      } catch (error: any) {  
        set((state) => { 
          state.notification.data.push({
            status: "ERROR",
            content: error?.response?.data?.message || error?.message || "Failed to update brand",
          });
        });
      }
    },
    deleteBrand: async (brandId: string) => {
      try {
        await apiClient.delete(`${apiEndpoints.Brand}/delete-brand/${brandId}`);
        set((state) => {
          state.brands.brands = state.brands.brands.filter(brand => brand.brandId !== brandId);
        });
      } catch (error: any) {
        set((state) => {
          state.notification.data.push({
            status: "ERROR",
            content: error?.response?.data?.message || error?.message || "Failed to delete brand",
          });
        });
      }
    }
  };
}