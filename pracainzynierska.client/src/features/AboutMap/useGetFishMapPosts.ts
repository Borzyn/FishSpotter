import { useMutation } from "@tanstack/react-query";

import { getFishMapPostsApi } from "../../services/apiMap";

export function useGetFishMapPosts() {
  const {
    isPending: isGettingsPosts,
    mutate: getFishMapPosts,
    data: fishPosts,
  } = useMutation({
    mutationFn: ({
      fishname,
      mapName,
    }: {
      fishname: string;
      mapName: string;
    }) => getFishMapPostsApi({ fishname, mapName }),
  });

  return { isGettingsPosts, getFishMapPosts, fishPosts };
}
