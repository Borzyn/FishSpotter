import { useQuery } from "@tanstack/react-query";
import { getPostRateApi } from "../../services/apiMap";

export function useGetPostRate(username: string, postId: string) {
  const { data } = useQuery({
    queryKey: ["postRate"],
    queryFn: () => getPostRateApi(username, postId),
  });

  return {
    data,
  };
}
