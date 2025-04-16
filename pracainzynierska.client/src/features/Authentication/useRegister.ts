import { useMutation } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { createAccountApi } from "../../services/apiAuth";

export interface IRegisterData {
  username: string;
  password: string;
  passwordConfirmed: string;
  termsAccept: boolean;
}

export function useRegister() {
  const { isPending: isCreatingAccount, mutate: createAccount } = useMutation({
    mutationFn: (data: IRegisterData) => createAccountApi(data),
    onSuccess: () => {
      toast.success("Account succesfully created");
    },
    onError: (error) => {
      toast.error(error.message);
    },
  });

  return { isCreatingAccount, createAccount };
}
