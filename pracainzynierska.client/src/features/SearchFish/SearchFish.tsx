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
        className="inline-block bg-white border-transparent shadow-sm shadow-slate-900/50 border-2 py-0.5 px-3 w-full transition-colors duration-500 rounded-sm text-lg outline-none focus:border-sky-500 focus-visible:border-sky-500"
      />
      <Button buttonType="button" type="primary" onClick={() => {}}>
        Search
      </Button>
    </div>
  );
}

export default SearchFish;
