import { Outlet } from "react-router";
import Header from "../../components/Header/Header";

function Layout() {
  return (
    <div className="min-h-dvh flex flex-col bg-blue-50 text-light">
      <Header />
      <main className="px-3 grow py-8 ">
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
