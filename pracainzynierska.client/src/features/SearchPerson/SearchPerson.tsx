import { Search, X } from "lucide-react";
import React, { useState } from "react";
import { useSearchUser } from "./useSearchUser";
import { useNavigate } from "react-router";

function SearchPerson() {
  const { isSearchingUser, searchUser } = useSearchUser();
  const navigate = useNavigate();
  const [query, setQuery] = useState<string>("");

  function clearQuery() {
    setQuery("");
  }

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    if (isSearchingUser) return;
    if (!query) return;

    searchUser(
      { accountCheckedName: query },
      {
        onError: () => setQuery(""),
        onSuccess: () => {
          setQuery("");
          navigate("/ab");
        },
      }
    );
  }

  return (
    <form className="relative w-full" onSubmit={handleSubmit}>
      <button
        type="submit"
        className="absolute top-6/12 left-1.5 -translate-y-6/12 cursor-pointer duration-500 text-slate-900 hover:text-sky-500"
        disabled={isSearchingUser}
      >
        <Search />
      </button>
      <button
        type="button"
        onClick={clearQuery}
        disabled={isSearchingUser}
        className="absolute top-6/12 right-1.5 -translate-y-6/12 cursor-pointer transition-colors duration-500 text-slate-900 hover:text-sky-500"
      >
        <X />
      </button>
      <input
        type="text"
        placeholder="Find person..."
        className="inline-block bg-white border-transparent shadow-md shadow-slate-900/50 border-2 py-0.5 px-9.5 w-full transition-colors duration-500 rounded-sm text-lg outline-none focus:border-sky-500 focus-visible:border-sky-500"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
      />
    </form>
  );
}

export default SearchPerson;
