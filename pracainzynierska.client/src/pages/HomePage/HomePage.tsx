import LineDivider from "../../components/LineDivider/LineDivider";
import ListLink from "../../components/ListLink/ListLink";
import SearchFish from "../../features/SearchFish/SearchFish";

function HomePage() {
  return (
    <div className="grid grid-cols-1 gap-y-13 justify-items-center">
      <section className="bg-white border-blue-100 border-4 max-w-80 w-full py-3 px-4 rounded-sm">
        <h2 className="text-3xl text-slate-900 uppercase text-center font-semibold">
          Maps
        </h2>
        <LineDivider color="bg-slate-900" margin="4" height="1" />
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

      <section className="bg-white border-blue-100 border-4 max-w-80 w-full py-3 px-4 rounded-sm">
        <div className="flex flex-col gap-2">
          <h2 className="text-3xl text-slate-900 uppercase text-center font-semibold">
            Fish
          </h2>
          <SearchFish />
        </div>
        <LineDivider color="bg-slate-900" margin="4" height="1" />
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
