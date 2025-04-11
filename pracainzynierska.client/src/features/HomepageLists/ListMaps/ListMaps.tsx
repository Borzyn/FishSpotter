import { useListMaps } from "../useListMaps";

function ListMaps() {
  const { isLoadingMaps, isMapsError, mapsError, listMapsData } = useListMaps();

  if (isMapsError) {
    return <p>{mapsError?.message}</p>;
  }

  if (isLoadingMaps) {
    return <p>Loading</p>;
  }

  console.log(listMapsData);

  return (
    <ul className="flex flex-col gap-4 h-full max-h-[625px] overflow-y-scroll"></ul>
  );
}

export default ListMaps;
