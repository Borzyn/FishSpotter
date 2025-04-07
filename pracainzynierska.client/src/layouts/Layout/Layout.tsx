import { Outlet } from "react-router";
import Header from "../../components/Header/Header";

function Layout() {
  return (
    <div className="max-w-dvw min-h-dvh grid grid-rows-[max-content_1fr] bg-blue-50 text-light">
      <Header />
      <main className="px-3 py-8">
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
