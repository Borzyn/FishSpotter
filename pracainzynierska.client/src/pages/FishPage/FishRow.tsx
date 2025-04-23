import { useEffect } from "react";
import { useMapPostsNumber } from "../../features/AboutFish/useMapPostsNumber";

function FishRow({
  mapNameProp,
  fishNameProp,
}: {
  mapNameProp: string;
  fishNameProp: string;
}) {
  const { getMapPostNumber, numberOfPosts } = useMapPostsNumber();

  useEffect(() => {
    getMapPostNumber({ fishName: fishNameProp, mapName: mapNameProp });
  }, [fishNameProp, getMapPostNumber, mapNameProp]);

  return (
    <tr className="grid grid-cols-2 text-lg font-medium py-3">
      <td>{mapNameProp}</td>
      <td>{numberOfPosts?.length}</td>
    </tr>
  );
}

export default FishRow;
