import { useParams } from "react-router";
import { useFishOnMap } from "./useFishOnMap";
import Loader from "../../components/Loaders/Loader/Loader";
import Error from "../../components/Error/Error";

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
      <div className="min-w-6xl overflow-hidden"></div>
    </div>
  );
}

export default FishMapTable;
