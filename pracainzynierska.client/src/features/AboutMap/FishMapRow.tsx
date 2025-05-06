import StarRating from "../../components/Rating/Rating";

export interface IPost {
  id: string;
  additionalInfo: string;
  bait: string;
  groundbait: string;
  method: string;
  spot: { xy: string };
  rateSum: number;
}

function FishMapRow({ post }: { post: IPost }) {
  return (
    <div className="py-2 px-4 grid grid-cols-7 bg-amber-50">
      <p>{post.method}</p>
      <p>{post.bait}</p>
      <p>{post.groundbait}</p>
      <p>{post.additionalInfo}</p>
      <p>XY: {post.spot.xy}</p>
      <p>Ocena: {post.rateSum}</p>
      <p>
        <StarRating />
      </p>
    </div>
  );
}

export default FishMapRow;
