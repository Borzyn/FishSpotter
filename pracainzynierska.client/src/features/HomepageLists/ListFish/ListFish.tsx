import Error from "../../../components/Error/Error";
import ListButton from "../../../components/ListButton/ListButton";
import Loader from "../../../components/Loaders/Loader/Loader";
import { useListFish } from "../useListFish";

function ListFish() {
  const { isFishError, isLoadingFish, fishError, listFishData } = useListFish();

  if (isFishError) {
    return <Error error={fishError?.message} />;
  }

  if (isLoadingFish) {
    return <Loader />;
  }

  return (
    <ul className="flex flex-col gap-4 max-h-[480px]  overflow-y-auto">
      {listFishData.map((fish: string) => (
        <ListButton key={fish} fish={fish} />
      ))}
    </ul>
  );
}

export default ListFish;
