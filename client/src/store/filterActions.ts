import type { StoreGet, StoreSet } from "../store";
import { apiClient, apiEndpoints } from "./utils.api";

export interface FilterState {
  brands: any[];
  categories: any[];
  functions: any[];
  ingredients: any[];
  skinTypes: any[];
}

export interface FilterActions {
  fetchFilters: () => Promise<void>;
}

export const initialFilter: FilterState = {
  brands: [],
  categories: [],
  functions: [],
  ingredients: [],
  skinTypes: [],
};

function parseData(response: any) {
  if (response?.$values) return response.$values;
  if (Array.isArray(response)) return response;
  return [];
}

export function filterActions(set: StoreSet, get: StoreGet): FilterActions {
  const fetchFilters = async () => {
    set((state) => {
      state.loading.isLoading = true;
    });

    try {
      const [
        brandsRes,
        categoriesRes,
        functionsRes,
        ingredientsRes,
        skinTypesRes,
      ] = await Promise.all([
        apiClient.get(`${apiEndpoints.Brand}/get-brands`),
        apiClient.get(`${apiEndpoints.Category}/get-categories`),
        apiClient.get(`${apiEndpoints.Function}/get-functions`),
        apiClient.get(`${apiEndpoints.Ingredient}/get-ingredients`),
        apiClient.get(`${apiEndpoints.SkinType}/get-all-skin-type`),
      ]);

      set((state) => {
        state.filter.brands = parseData(brandsRes.data);
        state.filter.categories = parseData(categoriesRes.data);
        state.filter.functions = parseData(functionsRes.data);
        state.filter.ingredients = parseData(ingredientsRes.data);
        state.filter.skinTypes = parseData(skinTypesRes.data);
      });
    } catch (error) {
      console.error("Error fetching filters:", error);
    } finally {
      set((state) => {
        state.loading.isLoading = false;
      });
    }
  };

  return {
    fetchFilters,
  };
}