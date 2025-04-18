import LineDivider from "../../components/LineDivider/LineDivider";

import ListFish from "../../features/HomepageLists/ListFish/ListFish";
import ListMaps from "../../features/HomepageLists/ListMaps/ListMaps";
import SearchFish from "../../features/SearchFish/SearchFish";

function HomePage() {
  return (
    <section className="grid grid-cols-1 gap-y-13 justify-items-center items-start  mx-auto max-w-7xl md:grid-cols-2 md:gap-x-4">
      <div className="bg-white border-blue-100 border-4 max-w-11/12 w-full py-3 px-4 rounded-sm md:max-w-[450px] max-h-[732px] overflow-hidden">
        <h2 className="text-3xl text-slate-900 uppercase text-center font-semibold">
          Maps
        </h2>
        <LineDivider color="bg-slate-900" margin="my-4" height="h-1" />
        <ListMaps />
      </div>

      <div className="bg-white border-blue-100 border-4 max-w-11/12 w-full py-3 px-4 rounded-sm md:max-w-[450px]">
        <div className="flex flex-col gap-2">
          <h2 className="text-3xl text-slate-900 uppercase text-center font-semibold">
            Fish
          </h2>
          <SearchFish />
        </div>
        <LineDivider color="bg-slate-900" margin="my-4" height="h-1" />
        <ListFish />
      </div>
    </section>
  );
}

export default HomePage;
