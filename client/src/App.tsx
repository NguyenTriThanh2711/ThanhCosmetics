import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { ThemeProvider } from "@mui/material";
import theme from "./theme";
import CustomerLayout from "./layouts/CustomerLayout";
import Home from "./pages/home/Home";
function App() {

  const isAuthenticated = !!localStorage.getItem("token");

  const router = createBrowserRouter([
    // { path: "login", element: <Login /> },
    // { path: "register", element: <Register /> },

    {
      path: "",
      element: <CustomerLayout />,
      children: [
        { path: "/", element: <Home /> },
        
      ],
    },
  ]);

  return (
    <ThemeProvider theme={theme}>
      <RouterProvider router={router} />
      {/* <Loading />
      <Notification /> */}
    </ThemeProvider>
  );
}

export default App;