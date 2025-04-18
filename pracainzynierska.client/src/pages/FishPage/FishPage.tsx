import { useParams } from "react-router";
import { useFishMaps } from "../../features/AboutFish/useFishMaps";
import { useEffect } from "react";
import FishRow from "./FishRow";

function FishPage() {
  const { fishName } = useParams();
  const { isSearchingFishMaps, getFishMaps, fishMaps } = useFishMaps();

  if (isSearchingFishMaps) {
    <p>Loading</p>;
  }

  useEffect(() => {
    if (fishName) getFishMaps({ fishName });
  }, [fishName, getFishMaps]);

  console.log(fishMaps);

  return (
    <section className="w-full h-full mx-auto max-w-7xl">
      <table className="m-auto min-w-80 text-center grid grid-cols-1 rounded-sm overflow-hidden">
        <caption className="text-3xl mb-5 font-medium tracking-wide">
          {fishName}
        </caption>
        <thead>
          <tr className="grid grid-cols-2 text-xl py-3">
            <th>Maps</th>
            <th>Number of Posts</th>
          </tr>
        </thead>
        <tbody>
          {fishMaps &&
            fishName &&
            fishMaps.map((map) => (
              <FishRow fishName={fishName} mapName={map.name} />
            ))}
        </tbody>
      </table>
    </section>
  );
}

export default FishPage;
