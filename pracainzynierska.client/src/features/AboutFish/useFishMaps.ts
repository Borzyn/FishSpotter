import { useMutation } from "@tanstack/react-query";
import { getFishMapsApi } from "../../services/apiFish";

export function useFishMaps() {
  const { isPending: isSearchingFishMaps, mutate: getFishMaps } = useMutation({
    mutationFn: ({ fishName }: { fishName: string }) =>
      getFishMapsApi(fishName),
  });

  return { isSearchingFishMaps, getFishMaps };
}
