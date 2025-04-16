import { useMutation } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { loginToAccountApi } from "../../services/apiAuth";
import { IUser, useUserStore } from "../../stores/useUserStore";

export interface ILoginData {
  login: string;
  password: string;
}

export function useLogin() {
  const { login } = useUserStore();
  const { isPending: isLoggingToAccount, mutate: loginToAccount } = useMutation(
    {
      mutationFn: (data: ILoginData) => loginToAccountApi(data),
      onSuccess: (data: IUser) => {
        login(data);
        toast.success("Sucessfully logged in");
      },
      onError: (error) => {
        toast.error(error.message);
      },
    }
  );

  return { isLoggingToAccount, loginToAccount };
}
