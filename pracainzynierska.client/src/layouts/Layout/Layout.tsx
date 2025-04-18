import { Outlet } from "react-router";
import Header from "../../components/Header/Header";
import { useMediaQuery } from "react-responsive";
import HeaderMobile from "../../components/Header/HeaderMobile";

function Layout() {
  const isMobile = useMediaQuery({
    query: "(max-width: 768px)",
  });

  return (
    <div className="min-h-dvh flex flex-col bg-blue-50 text-light">
      {isMobile ? <HeaderMobile /> : <Header />}
      <main className="px-3 grow py-8 ">
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
