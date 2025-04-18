import ListButton from "../../../components/ListButton/ListButton";
import { useListFish } from "../useListFish";

function ListFish() {
  const { isFishError, isLoadingFish, fishError, listFishData } = useListFish();

  if (isFishError) {
    return <p>{fishError?.message}</p>;
  }

  if (isLoadingFish) {
    return <p>Loading</p>;
  }

  return (
    <ul className="flex flex-col gap-4 max-h-[584px] overflow-y-auto">
      {listFishData.map((fish: string) => (
        <ListButton key={fish} fish={fish} />
      ))}
    </ul>
  );
}

export default ListFish;
