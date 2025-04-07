import { Search, X } from "lucide-react";
import { useState } from "react";

function SearchPerson() {
  const [query, setQuery] = useState<string>("");

  function clearQuery() {
    setQuery("");
  }

  return (
    <form className="relative w-full">
      <button className="absolute top-6/12 left-1.5 -translate-y-6/12 cursor-pointer">
        <Search />
      </button>
      <button
        onClick={clearQuery}
        className="absolute top-6/12 right-1.5 -translate-y-6/12 cursor-pointer"
      >
        <X />
      </button>
      <input
        type="text"
        placeholder="Find person..."
        className="inline-block bg-white border-transparent border-2 py-0.5 px-9.5 w-full transition-colors duration-500 rounded-sm text-lg outline-none focus:border-sky-500 focus-visible:border-sky-500"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
      />
    </form>
  );
}

export default SearchPerson;
