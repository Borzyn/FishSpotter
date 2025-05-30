import { MapPinned } from "lucide-react";
import StarRating from "../../components/Rating/Rating";

export interface IPost {
  id: string;
  additionalInfo: string;
  bait: string;
  groundbait: string;
  method: string;
  methodName: string;
  spot: { xy: string };
  rateSum: number;
  rateAmount: number;
}

function FishMapRow({ post }: { post: IPost }) {
  return (
    <div className="py-2 px-4 grid grid-cols-7 bg-amber-50">
      <p>{post.methodName}</p>
      <p>{post.bait}</p>
      <p>{post.groundbait}</p>
      <p>{post.additionalInfo}</p>
      <p className="flex items-center gap-4">
        XY: {post.spot.xy}{" "}
        <button className="cursor-pointer">
          <MapPinned />
        </button>
      </p>
      <p>Ocena: {post.rateAmount === 0 ? 0 : post.rateSum / post.rateAmount}</p>

      <StarRating />
    </div>
  );
}

export default FishMapRow;
