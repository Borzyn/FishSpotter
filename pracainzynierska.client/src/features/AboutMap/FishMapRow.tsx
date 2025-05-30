import { MapPinned } from "lucide-react";
import StarRating from "../../components/Rating/Rating";

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

function FishMapRow({ post }: { post: IPost }) {
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

      <StarRating />
    </div>
  );
}

export default FishMapRow;
