import { useQuery } from "@tanstack/react-query";
import { getFishMapApi } from "../../services/apiMap";

export function useFishOnMap(mapName?: string) {
  const { isError, error, isPending, data } = useQuery({
    queryKey: ["fishMap"],
    queryFn: () => getFishMapApi(mapName),
  });

  return {
    isError,
    error,
    isPending,
    data,
  };
}
