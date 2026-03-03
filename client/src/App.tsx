import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { ThemeProvider } from "@mui/material";
import theme from "./theme";
import Home from "./pages/home/Home";
import ProtectedRoute from "./utils/ProtectedRoute";
import Loading from "./components/loading/Loading";
import { useStore } from "./store";
import { useMemo, useEffect } from "react";
import CustomerLayout from "./layouts/CustomerLayout";
import Cart from "./pages/cart/Cart";
import Profile from "./pages/profile/Profile";
import BrandList from "./pages/brand/BrandList";
import Notification from "./components/notification/Notification";
import Purchase from "./pages/purchase/Purchase";
import PurchaseDetail from "./pages/purchase/PurchaseDetail";
import Checkout from "./pages/checkout/Checkout";
import CheckoutSuccess from "./pages/checkout/CheckoutCOD";
import ProductList from "./pages/product/ProductList";
import ProductDetail from "./pages/product/ProductDetail";
import SaleProducts from "./pages/sale/SaleProducts";
import Login from "./pages/login/Login";
import SkinTestQuiz from "./pages/quiz/SkinTestQuiz";
import SkinTestResult from "./pages/skin-test-result/SkinTestResult";
import BlogDetail from "./pages/blog/BlogDetail";
import OurBlog from "./pages/blog/OurBlog";
import Compare from "./pages/compare/Compare";
import Register from "./pages/register/Register";

function App() {
  const user = useStore((store) => store.profile.user);
  const token = localStorage.getItem("token");
  const role = useMemo(() => {
    if (user?.role) return user.role;
    if (token) return localStorage.getItem("role");
    return null;
  }, [user, token]);

  const isAuthenticated = !!localStorage.getItem("token");

  const router = createBrowserRouter([
    { path: "login", element: <Login /> },
    { path: "register", element: <Register /> },

    {
      path: "",
      element: <CustomerLayout />,
      children: [
        { path: "/", element: <Home /> },
        { path: "take-quiz", element: <SkinTestQuiz /> },
        { path: "products", element: <ProductList /> },
        {
          path: "quiz-result",
          element: (
            <ProtectedRoute
              isAllowed={isAuthenticated && role === "Customer"}
              redirectPath="/login"
            >
              <SkinTestResult />
            </ProtectedRoute>
          ),
        },
        { path: "product/:id", element: <ProductDetail /> },
        { path: "sales", element: <SaleProducts /> },
        { path: "blogs", element: <OurBlog /> },
        { path: "blogs/:id", element: <BlogDetail /> },
        { path: "brands", element: <BrandList /> },
        { path: "purchase", element: <Purchase /> },
        { path: "purchase/:id", element: <PurchaseDetail /> },
        { path: "compare", element: <Compare /> },
        {
          path: "cart",
          element: (
            <ProtectedRoute
              isAllowed={isAuthenticated && role === "Customer"}
              redirectPath="/login"
            >
              <Cart />
            </ProtectedRoute>
          ),
        },
        { path: "checkout", element: <Checkout /> },
        {
          path: "profile",
          element: (
            <ProtectedRoute
              isAllowed={isAuthenticated && role === "Customer"}
              redirectPath="/login"
            >
              <Profile />
            </ProtectedRoute>
          ),
        },
        {
          path: "order-success",
          element: (
            <ProtectedRoute
              isAllowed={isAuthenticated && role === "Customer"}
              redirectPath="/login"
            >
              <CheckoutSuccess />
            </ProtectedRoute>
          ),
        },
      ],
    }
  ]);

  return (
    <ThemeProvider theme={theme}>
      <RouterProvider router={router} />
      <Loading />
      <Notification />
    </ThemeProvider>
  );
}

export default App;