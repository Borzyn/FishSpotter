import { useMutation } from "@tanstack/react-query";
import { getFishMapPostsNumberApi } from "../../services/apiFish";

export function useMapPostsNumber() {
  const { isPending: isCountingMapPosts, mutate: getMapPostNumber } =
    useMutation({
      mutationFn: ({
        fishName,
        mapName,
      }: {
        fishName: string;
        mapName: string;
      }) => getFishMapPostsNumberApi({ fishName, mapName }),
    });

  return { isCountingMapPosts, getMapPostNumber };
}
