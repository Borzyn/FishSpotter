import { LogOut } from "lucide-react";
import { useLogout } from "../../features/Authentication/useLogout";
import { useNavigate } from "react-router";

function UserProfile({ username }: { username: string }) {
  const navigate = useNavigate();
  const { logoutFromAccount, isLoggingOut } = useLogout();

  function handleLogout() {
    logoutFromAccount();
  }

  return (
    <div className="flex gap-3 items-center">
      <button
        onClick={() => navigate(`/profile/${username}`)}
        disabled={isLoggingOut}
        className="text-white w-full h-full block text-lg bg-sky-500 px-2.5 py-1 rounded-md text-nowrap cursor-pointer"
      >
        {username}
      </button>

      <button
        onClick={handleLogout}
        disabled={isLoggingOut}
        className="cursor-pointer text-sky-500"
      >
        <LogOut size={32} />
      </button>
    </div>
  );
}

export default UserProfile;
