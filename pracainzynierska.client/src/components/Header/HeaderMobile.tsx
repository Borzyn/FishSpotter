import AuthModal from "../../features/Authentication/AuthModal/AuthModal";
import SearchPerson from "../../features/SearchPerson/SearchPerson";
import { useUserStore } from "../../stores/useUserStore";
import Logo from "../Logo/Logo";

import UserProfile from "../UserProfile/UserProfile";

function HeaderMobile() {
  const { user } = useUserStore();

  return (
    <header className="grid grid-cols-1 gap-x-4 gap-y-2.5 items-center  bg-sky-900 py-2 px-2.5">
      <div className="flex gap-4 justify-between items-center">
        <Logo />
        {user ? <UserProfile username={user.username} /> : <AuthModal />}
      </div>
      <SearchPerson />
    </header>
  );
}

export default HeaderMobile;
