import { LogOut } from "lucide-react";

function UserProfile({ username }: { username: string }) {
  return (
    <div className="flex gap-3 items-center">
      <button className="text-white w-full h-full block text-lg bg-sky-500 px-2.5 py-1 rounded-md text-nowrap cursor-pointer">
        {username}
      </button>

      <button className="cursor-pointer text-sky-500">
        <LogOut size={32} />
      </button>
    </div>
  );
}

export default UserProfile;
