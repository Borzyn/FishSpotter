import AuthModal from "../../features/Authentication/AuthModal/AuthModal";
import SearchPerson from "../../features/SearchPerson/SearchPerson";
import Logo from "../Logo/Logo";

function Header() {
  return (
    <header className="flex gap-x-4 items-center justify-between bg-emerald-800 text-gray-800 py-2 px-2.5">
      <Logo />
      <div className="flex gap-4 items-center">
        <SearchPerson />
        <AuthModal />
      </div>
    </header>
  );
}

export default Header;
