import { lazy, Suspense } from "react";
import { BrowserRouter, Route, Routes } from "react-router";
import LoaderFull from "./components/Loaders/LoaderFull/LoaderFull";
import FishPage from "./pages/FishPage/FishPage";
import ProfilePage from "./pages/ProfilePage/ProfilePage";
import FishMapPage from "./pages/FishMapPage/FishMapPage";
import AddPostPage from "./pages/AddPostPage/AddPostPage";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { Toaster } from "react-hot-toast";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import PageNotFound from "./pages/PageNotFound/PageNotFound";
import ProtectedRoute from "./components/ProtectedRoute/ProtectedRoute";

const Layout = lazy(() => import("./layouts/Layout/Layout"));
const HomePage = lazy(() => import("./pages/HomePage/HomePage"));

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Suspense fallback={<LoaderFull />}>
          <Routes>
            <Route element={<Layout />}>
              <Route index element={<HomePage />} />
              <Route path="/fish/:fishName" element={<FishPage />} />
              <Route path="/map/:mapName" element={<FishMapPage />} />
              <Route path="/profile/:username" element={<ProfilePage />} />
              <Route
                path="/profile/addpost"
                element={
                  <ProtectedRoute>
                    <AddPostPage />
                  </ProtectedRoute>
                }
              />
              <Route path="*" element={<PageNotFound />} />
            </Route>
          </Routes>
        </Suspense>
        <ReactQueryDevtools initialIsOpen={false} />
      </BrowserRouter>

      <Toaster
        position="top-center"
        gutter={12}
        containerStyle={{ margin: "8px", zIndex: "1000" }}
        toastOptions={{
          style: {
            backgroundColor: "oklch(0.987 0.022 95.277)",
            color: "#292524",
            font: "inherit",
            fontWeight: "500",
          },
          success: {
            duration: 5000,
          },
          error: {
            duration: 5000,
          },
        }}
      />
    </QueryClientProvider>
  );
}

export default App;
