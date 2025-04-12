import { useMutation } from "@tanstack/react-query";
import toast from "react-hot-toast";
import { getAccountPostsApi } from "../../services/apiAccount";

export function useAccountPosts() {
  const { isPending: isGettingPosts, mutate: getUserPosts } = useMutation({
    mutationFn: ({ accountName }: { accountName: string }) =>
      getAccountPostsApi(accountName),
    onError: () => {
      toast.error("User does not exist");
    },
  });

  return { isGettingPosts, getUserPosts };
}
