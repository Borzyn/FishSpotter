import { useEffect } from "react";
import { useMapPostsNumber } from "../../features/AboutFish/useMapPostsNumber";

function FishRow({
  mapNameProp,
  fishNameProp,
}: {
  mapNameProp: string;
  fishNameProp: string;
}) {
  const { getMapPostNumber, isCountingMapPosts, numberOfPosts } =
    useMapPostsNumber();

  useEffect(() => {
    getMapPostNumber({ fishName: fishNameProp, mapName: mapNameProp });
  }, [fishNameProp, getMapPostNumber, mapNameProp]);

  if (isCountingMapPosts) {
    return <p>Loading</p>;
  }

  return (
    <tr className="grid grid-cols-2 text-lg font-medium py-3">
      <td>{mapNameProp}</td>
      <td>4</td>
    </tr>
  );
}

export default FishRow;
