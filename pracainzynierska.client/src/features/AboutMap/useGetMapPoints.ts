import { useQuery } from "@tanstack/react-query";
import { getMapPointsApi } from "../../services/apiMap";

export function useGetMapPoints(mapName?: string) {
  const { isError, error, isPending, data } = useQuery({
    queryKey: ["mapPoints", mapName],
    queryFn: () => getMapPointsApi(mapName),
  });

  return {
    isError,
    error,
    isPending,
    data,
  };
}
