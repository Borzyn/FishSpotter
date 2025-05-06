import { useMutation } from "@tanstack/react-query";
import { createPostApi } from "../../services/apiPost";

export interface ICreatePost {
  map: string;
  fish: string;
  method: string;
  bait: string;
  additionalInformation: string;
  locationX: string;
  locationY: string;
}

export function useCreatePost() {
  const { isPending: isCreatingPost, mutate: createPost } = useMutation({
    mutationFn: (postData: ICreatePost) => createPostApi(postData),
  });

  return { isCreatingPost, createPost };
}
