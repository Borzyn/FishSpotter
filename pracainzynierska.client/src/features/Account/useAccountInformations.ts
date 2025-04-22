import { useMutation } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { getAccountInformationsApi } from "../../services/apiAccount";

export function useAccountInformations() {
  const {
    isPending: isGettingInformations,
    mutate: getUserInformations,
    data: userInformationsData,
  } = useMutation({
    mutationFn: ({ accountCheckedName }: { accountCheckedName: string }) =>
      getAccountInformationsApi(accountCheckedName),
    onError: () => {
      toast.error("User does not exist");
    },
  });

  return { isGettingInformations, getUserInformations, userInformationsData };
}
