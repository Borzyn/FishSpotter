import AuthModal from "../../features/Authentication/AuthModal/AuthModal";
import SearchPerson from "../../features/SearchPerson/SearchPerson";
import { useUserStore } from "../../stores/useUserStore";
import Logo from "../Logo/Logo";

import UserProfile from "../UserProfile/UserProfile";

function Header() {
  const { user } = useUserStore();

  console.log(user);

  return (
    <header className="flex gap-x-4 items-center justify-between bg-sky-900 py-2 px-2.5">
      <Logo />
      <div className="flex gap-4 items-center">
        <SearchPerson />

        {user ? <UserProfile username={user.username} /> : <AuthModal />}
      </div>
    </header>
  );
}

export default Header;
