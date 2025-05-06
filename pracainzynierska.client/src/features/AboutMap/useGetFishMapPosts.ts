import { useMutation } from "@tanstack/react-query";

import { getFishMapPostsApi } from "../../services/apiMap";

export function useGetFishMapPosts() {
  const {
    isPending: isGettingsPosts,
    mutate: getFishMapPosts,
    data: fishPosts,
  } = useMutation({
    mutationFn: ({
      fishName,
      mapName,
    }: {
      fishName: string;
      mapName: string;
    }) => getFishMapPostsApi({ fishName, mapName }),
  });

  return { isGettingsPosts, getFishMapPosts, fishPosts };
}
