import ListLink from "../../components/ListLink/ListLink";
import SearchFish from "../../features/SearchFish/SearchFish";

function HomePage() {
  return (
    <div className="grid grid-cols-1 gap-y-13 justify-items-center">
      <section className="bg-amber-300 max-w-80 w-full py-3 px-4 rounded-sm ">
        <h2 className="text-3xl uppercase text-center font-semibold">Maps</h2>
        <div className="w-full h-1 bg-red-500 my-3" aria-hidden="true"></div>
        <ul className="flex flex-col gap-4 max-h-[464px] overflow-auto">
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
        </ul>
      </section>

      <section className="bg-amber-300 max-w-80 w-full py-3 px-4 rounded-sm ">
        <div className="flex flex-col gap-2">
          <h2 className="text-3xl uppercase text-center font-semibold">Fish</h2>
          <SearchFish />
        </div>
        <div className="w-full h-1 bg-red-500 my-3" aria-hidden="true"></div>
        <ul className="flex flex-col gap-4 max-h-[464px] overflow-auto">
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
          <ListLink />
        </ul>
      </section>
    </div>
  );
}

export default HomePage;
