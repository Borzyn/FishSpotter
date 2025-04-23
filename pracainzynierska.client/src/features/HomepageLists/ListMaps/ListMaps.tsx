import Error from "../../../components/Error/Error";
import ListButton from "../../../components/ListButton/ListButton";
import Loader from "../../../components/Loaders/Loader/Loader";
import { useListMaps } from "../useListMaps";

function ListMaps() {
  const { isLoadingMaps, isMapsError, mapsError, listMapsData } = useListMaps();

  if (isMapsError) {
    return <Error error={mapsError?.message} />;
  }

  if (isLoadingMaps) {
    return <Loader />;
  }

  return (
    <ul className="flex flex-col gap-4 h-full max-h-[625px] overflow-y-auto">
      {listMapsData.map((map: string) => (
        <ListButton key={map} map={map} />
      ))}
    </ul>
  );
}

export default ListMaps;
