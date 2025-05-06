import { useParams } from "react-router";
import { useFishMaps } from "../../features/AboutFish/useFishMaps";
import { useEffect } from "react";
import FishRow from "./FishRow";
import Loader from "../../components/Loaders/Loader/Loader";

function FishPage() {
  const { fishName } = useParams();
  const { isSearchingFishMaps, getFishMaps, fishMaps } = useFishMaps();

  useEffect(() => {
    if (fishName) getFishMaps({ fishName });
  }, [fishName, getFishMaps]);

  if (isSearchingFishMaps) {
    return <Loader />;
  }

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
            fishMaps.Maps.map((map: { Name: string }) => (
              <FishRow
                key={map.Name}
                fishNameProp={fishName}
                mapNameProp={map.Name}
              />
            ))}
        </tbody>
      </table>
    </section>
  );
}

export default FishPage;
