import { useParams } from "react-router";
import FishMapTable from "../../features/AboutMap/FishMapTable";
import Map from "../../features/AboutMap/Map";

function FishMapPage() {
  const { mapName } = useParams();

  return (
    <section className="w-full h-full mx-auto max-w-7xl">
      <Map />

      <div className="mt-6 mb-10 text-center">
        <p className="text-lg font-medium">Łowisko</p>
        <p className="text-3xl font-semibold">{mapName}</p>
      </div>

      <FishMapTable />
    </section>
  );
}

export default FishMapPage;
