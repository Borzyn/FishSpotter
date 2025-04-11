import { useQuery } from "@tanstack/react-query";
import { getListMapsApi } from "../../services/apiLists";

export function useListMaps() {
  const {
    isPending: isLoadingMaps,
    isError: isMapsError,
    data: listMapsData,
    error: mapsError,
  } = useQuery({
    queryKey: ["listMaps"],
    queryFn: getListMapsApi,
  });

  return { isLoadingMaps, isMapsError, listMapsData, mapsError };
}
