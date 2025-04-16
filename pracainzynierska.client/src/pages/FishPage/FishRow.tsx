import { useEffect } from "react";
import { useMapPostsNumber } from "../../features/AboutFish/useMapPostsNumber";

function FishRow({ mapName, fishName }: { mapName: string; fishName: string }) {
  const { getMapPostNumber, isCountingMapPosts, numberOfPosts } =
    useMapPostsNumber();

  if (isCountingMapPosts) {
    <p>Loading</p>;
  }

  useEffect(() => {
    getMapPostNumber({ fishName, mapName });
  }, [fishName, getMapPostNumber, mapName]);

  return (
    <tr className="grid grid-cols-2 text-lg font-medium py-3">
      <td>Pond</td>
      <td>4</td>
    </tr>
  );
}

export default FishRow;
