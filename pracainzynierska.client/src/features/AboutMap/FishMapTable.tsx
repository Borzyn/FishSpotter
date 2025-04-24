import { useParams } from "react-router";
import { useFishOnMap } from "./useFishOnMap";
import Loader from "../../components/Loaders/Loader/Loader";
import Error from "../../components/Error/Error";
import FishMapTableRow from "./FishMapTableRow";

function FishMapTable() {
  // const { mapName } = useParams();
  // const { isError, error, data, isPending } = useFishOnMap(mapName);

  // if (isPending) {
  //   return <Loader />;
  // }

  // if (isError) {
  //   return <Error error={error?.message} />;
  // }

  return (
    <div className="w-full overflow-auto">
      <ul className="min-w-6xl overflow-hidden flex flex-col gap-2">
        <FishMapTableRow />
        <FishMapTableRow />
        <FishMapTableRow />
      </ul>
    </div>
  );
}

export default FishMapTable;
