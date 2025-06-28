import { useQuery } from "@tanstack/react-query";

import { getFishMapPostsApi } from "../../services/apiMap";

export function useGetFishMapPosts(fishName: string, mapName: string) {
  const { data, isError, error, isPending } = useQuery({
    queryKey: ["getFishMapPosts"],
    queryFn: () => getFishMapPostsApi(fishName, mapName),
  });

  return { data, isError, error, isPending };
}
