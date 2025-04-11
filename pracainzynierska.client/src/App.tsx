import { lazy, Suspense } from "react";
import { BrowserRouter, Route, Routes } from "react-router";
import LoaderFull from "./components/Loaders/LoaderFull/LoaderFull";
import FishPage from "./pages/FishPage/FishPage";
import ProfilePage from "./pages/ProfilePage/ProfilePage";
import FishMapPage from "./pages/FishMapPage/FishMapPage";
import AddPostPage from "./pages/AddPostPage/AddPostPage";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

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
              <Route path="/fish" element={<FishPage />} />
              <Route path="/fishmap" element={<FishMapPage />} />
              <Route path="/addpost" element={<AddPostPage />} />
              <Route path="/profile" element={<ProfilePage />} />
            </Route>
          </Routes>
        </Suspense>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
