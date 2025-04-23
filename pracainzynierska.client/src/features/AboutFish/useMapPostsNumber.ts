import { useMutation } from "@tanstack/react-query";
import { getFishMapPostsNumberApi } from "../../services/apiFish";

export interface IFishMapPosts {
  fishName: string;
  mapName: string;
}

export function useMapPostsNumber() {
  const {
    isPending: isCountingMapPosts,
    mutate: getMapPostNumber,
    data: numberOfPosts,
  } = useMutation({
    mutationFn: (data: IFishMapPosts) => getFishMapPostsNumberApi(data),
  });

  return { isCountingMapPosts, getMapPostNumber, numberOfPosts };
}
