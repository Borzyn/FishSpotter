import { Outlet } from "react-router";
import Header from "../../components/Header/Header";

function Layout() {
  return (
    <div className="w-dvw h-dvh grid grid-rows-[max-content_1fr] bg-green-50">
      <Header />
      <main>
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
