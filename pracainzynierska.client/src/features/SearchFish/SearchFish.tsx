import { useState } from "react";
import Button from "../../components/Button/Button";
import { useSearchFish } from "./useSearchFish";
import { useNavigate } from "react-router";

function SearchFish() {
  const { isSearchingFish, searchFish } = useSearchFish();
  const navigate = useNavigate();
  const [fishQuery, setFishQuery] = useState<string>("");

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    if (!fishQuery) return;

    searchFish(
      { fishName: fishQuery },
      {
        onSuccess: () => {
          navigate(`/fish/${fishQuery}`);
        },
        onError: () => setFishQuery(""),
      }
    );
  }

  return (
    <form className="flex gap-2" onSubmit={handleSubmit}>
      <input
        value={fishQuery}
        disabled={isSearchingFish}
        onChange={(e) => setFishQuery(e.target.value)}
        type="text"
        placeholder="Find your fish..."
        className="inline-block bg-white border-transparent shadow-sm shadow-slate-900/50 border-2 py-0.5 px-3 w-full transition-colors duration-500 rounded-sm text-lg outline-none focus:border-sky-500 focus-visible:border-sky-500"
      />
      <Button isDisable={isSearchingFish} buttonType="submit" type="primary">
        Search
      </Button>
    </form>
  );
}

export default SearchFish;
