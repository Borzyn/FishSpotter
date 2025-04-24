import { useParams } from "react-router";
import FishMapTable from "../../features/AboutMap/FishMapTable";

function FishMapPage() {
  const { mapName } = useParams();

  return (
    <section className="w-full h-full mx-auto max-w-7xl">
      <div className="w-full max-h-80 min-h-100 h-full bg-amber-200">Map</div>

      <div className="mt-6 mb-10 text-center">
        <p className="text-lg font-medium">Łowisko</p>
        <p className="text-3xl font-semibold">{mapName}</p>
      </div>

      <FishMapTable />
    </section>
  );
}

export default FishMapPage;
