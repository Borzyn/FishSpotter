import { useMutation } from "@tanstack/react-query";
import { searchUserApi } from "../../services/apiSearch";
import toast from "react-hot-toast";

export function useSearchUser() {
  const { isPending: isSearchingUser, mutate: searchUser } = useMutation({
    mutationFn: ({ accountCheckedName }: { accountCheckedName: string }) =>
      searchUserApi(accountCheckedName),
    onError: () => {
      toast.error("User does not exist");
    },
  });

  return { isSearchingUser, searchUser };
}
