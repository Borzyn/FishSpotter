import { useMutation } from "@tanstack/react-query";
import { setPostRateApi } from "../../services/apiMap";

export interface IPostRateData {
  user: string;
  postId: string;
  rate: number;
}

export function useRatePost() {
  const { mutate: ratePost, isPending: isRating } = useMutation({
    mutationFn: (rateData: IPostRateData) => setPostRateApi(rateData),
  });

  return { ratePost, isRating };
}
