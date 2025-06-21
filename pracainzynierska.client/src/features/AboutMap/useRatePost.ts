import { useMutation } from "@tanstack/react-query";
import { getPostRateApi } from "../../services/apiMap";

export interface IPostRateData {
  user: string;
  postId: string;
  rate: number;
}

export function useRatePost() {
  const { mutate: ratePost, isPending: isRating } = useMutation({
    mutationFn: (rateData: IPostRateData) => getPostRateApi(rateData),
  });

  return { ratePost, isRating };
}
