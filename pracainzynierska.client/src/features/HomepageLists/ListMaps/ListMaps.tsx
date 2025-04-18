import ListButton from "../../../components/ListButton/ListButton";
import { useListMaps } from "../useListMaps";

function ListMaps() {
  const { isLoadingMaps, isMapsError, mapsError, listMapsData } = useListMaps();

  if (isMapsError) {
    return <p>{mapsError?.message}</p>;
  }

  if (isLoadingMaps) {
    return <p>Loading</p>;
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
