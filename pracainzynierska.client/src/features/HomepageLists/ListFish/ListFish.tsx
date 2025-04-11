import { useListFish } from "../useListFish";

function ListFish() {
  const { isFishError, isLoadingFish, fishError, listFishData } = useListFish();

  if (isFishError) {
    return <p>{fishError?.message}</p>;
  }

  if (isLoadingFish) {
    return <p>Loading</p>;
  }

  console.log(listFishData);

  return <ul className="flex flex-col gap-4 max-h-[584px] overflow-auto"></ul>;
}

export default ListFish;
