import { useState } from "react";
import Button from "../../components/Button/Button";

function SearchFish() {
  const [fishQuery, setFishQuery] = useState<string>("");

  return (
    <div className="flex gap-2">
      <input
        value={fishQuery}
        onChange={(e) => setFishQuery(e.target.value)}
        type="text"
        placeholder="Find your fish..."
        className="bg-amber-50 min-w-16 text-stone-800 border-none px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl"
      />
      <Button buttonType="button" type="primary" onClick={() => {}}>
        Search
      </Button>
    </div>
  );
}

export default SearchFish;
