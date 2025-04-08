import { lazy, Suspense } from "react";
import { BrowserRouter, Route, Routes } from "react-router";
import LoaderFull from "./components/Loaders/LoaderFull/LoaderFull";
import FishPage from "./pages/FishPage/FishPage";

const Layout = lazy(() => import("./layouts/Layout/Layout"));
const HomePage = lazy(() => import("./pages/HomePage/HomePage"));

function App() {
  return (
    <BrowserRouter>
      <Suspense fallback={<LoaderFull />}>
        <Routes>
          <Route element={<Layout />}>
            <Route index element={<HomePage />} />
            <Route path="/fish" element={<FishPage />} />
          </Route>
        </Routes>
      </Suspense>
    </BrowserRouter>
  );
}

export default App;
