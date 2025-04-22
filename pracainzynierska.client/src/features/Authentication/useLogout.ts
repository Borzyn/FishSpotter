import { useMutation } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { logoutFromAccountApi } from "../../services/apiAuth";
import { useUserStore } from "../../stores/useUserStore";

export interface ILoginData {
  login: string;
  password: string;
}

export function useLogout() {
  const { logout } = useUserStore();
  const { isPending: isLoggingOut, mutate: logoutFromAccount } = useMutation({
    mutationFn: () => logoutFromAccountApi(),
    onSuccess: () => {
      logout();
      toast.success("Sucessfully logged out");
    },
    onError: (error) => {
      toast.error(error.message);
    },
  });

  return { isLoggingOut, logoutFromAccount };
}
