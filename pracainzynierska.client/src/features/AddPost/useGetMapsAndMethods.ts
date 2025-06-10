import { useQuery } from "@tanstack/react-query";
import { getMapsAndMethodsApi } from "../../services/apiPost";

function useGetMapsAndMethods() {
  const { isError, error, isPending, data } = useQuery({
    queryKey: ["mapsAndMethods"],
    queryFn: getMapsAndMethodsApi,
  });

  return {
    isError,
    error,
    isPending,
    data,
  };
}

export default useGetMapsAndMethods;
