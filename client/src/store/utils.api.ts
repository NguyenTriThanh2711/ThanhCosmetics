import axios,  { type AxiosInstance } from "axios";

 const apiBaseUrl: string =
  "https://beautysc-api.purpleforest-f01817f2.southeastasia.azurecontainerapps.io/api";

export const apiEndpoints = {
  SkinTest: "SkinTest",
  Customer: "Customer",
  Orders: "Orders",
  Payment: "Payment",
  SkinType: "SkinType",
  Routine: "Routine",
  Category: "Category",
  Voucher: "Voucher",
  Feedback: "Feedback",
  Product: "Product",
  Authentication: "Authentication",
  blogs: "blogs",
  Brand: "Brand",
  Function: "Function",
  Ingredient: "Ingredient",
} as const;

export const apiClient: AxiosInstance = axios.create({
  baseURL: apiBaseUrl,
  headers: {
    "Content-Type": "application/json"
  },
});

apiClient.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem("token");
      window.location.href = "/login";
    }
    return Promise.reject(error);
  }
);

export const setAuthToken = (token: string | null): void => {
  if (token) {
    apiClient.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  } else {
    delete apiClient.defaults.headers.common["Authorization"];
  }
};