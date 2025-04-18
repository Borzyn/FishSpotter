import { useMutation } from "@tanstack/react-query";
import { searchFishApi } from "../../services/apiSearch";
import toast from "react-hot-toast";

export function useSearchFish() {
  const { isPending: isSearchingFish, mutate: searchFish } = useMutation({
    mutationFn: ({ fishName }: { fishName: string }) => searchFishApi(fishName),
    onError: () => {
      toast.error("Fish not found!");
    },
  });

  return { isSearchingFish, searchFish };
}
