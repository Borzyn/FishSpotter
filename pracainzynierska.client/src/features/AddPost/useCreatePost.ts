import { useMutation } from "@tanstack/react-query";
import { createPostApi } from "../../services/apiPost";
import toast from "react-hot-toast";

export interface ICreatePost {
  user: string;
  mapname: string;
  fishname: string;
  methodname: string;
  baitname: string;
  groundbaitid: string;
  addInfo: string;
  spotID: string;
}

export function useCreatePost() {
  const { isPending: isCreatingPost, mutate: createPost } = useMutation({
    mutationFn: (postData: ICreatePost) => createPostApi(postData),
    onSuccess: () => toast.success("Dodano post"),
    onError: () => toast.error("Post nie został utworzony"),
  });

  return { isCreatingPost, createPost };
}
