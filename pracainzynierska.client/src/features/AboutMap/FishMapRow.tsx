import { MapPinned } from "lucide-react";
import StarRating from "../../components/Rating/Rating";
import { useRatePost } from "./useRatePost";
import { useUserStore } from "../../stores/useUserStore";
import { useGetPostRate } from "./useGetPostRate";
import { useQueryClient } from "@tanstack/react-query";

export interface IPost {
  id: string;
  additionalInfo: string;
  bait: { name: string };
  groundbait: { gbName: string };
  method: string;
  methodName: string;
  spot: { xy: string };
  rateSum: number;
  rateAmount: number;
}

function FishMapRow({ post, fishName }: { post: IPost; fishName: string }) {
  const queryClient = useQueryClient();
  const { user } = useUserStore();
  const { ratePost, isRating } = useRatePost();
  const { data: rate, isPending } = useGetPostRate(
    user?.username ?? "",
    post.id
  );

  function handleChangeRate(rate: number) {
    if (!user?.username) return;
    if (isRating) return;

    return null;

    ratePost(
      { user: user?.username, postId: post.id, rate },
      {
        onSuccess: () =>
          queryClient.invalidateQueries({
            queryKey: ["getFishMapPosts", fishName],
          }),
      }
    );
  }

  return (
    <div className="py-2 px-4 grid grid-cols-7 bg-amber-50">
      <p>{post.methodName}</p>
      <p className="text-center">{post.bait.name}</p>
      <p className="text-center">{post.groundbait.gbName}</p>
      <p className="text-center">{post.additionalInfo}</p>
      <p className="flex items-center justify-center gap-4">
        XY: {post.spot.xy}{" "}
        <button className="cursor-pointer">
          <MapPinned />
        </button>
      </p>
      <p className="text-center">
        Ocena: {post.rateAmount === 0 ? 0 : post.rateSum / post.rateAmount}
      </p>

      {isPending && <p>Loading...</p>}
      {!isPending && (
        <StarRating initialRating={rate ?? 0} onChange={handleChangeRate} />
      )}
    </div>
  );
}

export default FishMapRow;
