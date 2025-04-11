import { useQuery } from "@tanstack/react-query";
import { getListFishApi } from "../../services/apiLists";

export function useListFish() {
  const {
    isPending: isLoadingFish,
    isError: isFishError,
    data: listFishData,
    error: fishError,
  } = useQuery({
    queryKey: ["listFish"],
    queryFn: getListFishApi,
  });

  return { isLoadingFish, isFishError, listFishData, fishError };
}
