import { Link } from "react-router";

function ListLink() {
  return (
    <li>
      <Link
        className="block w-full h-full cursor-pointer bg-sky-600 text-blue-50 hover:bg-sky-500 visited:bg-sky-600 active:bg-sky-600 text-center py-2 text-xl font-medium rounded-sm transition-colors duration-500"
        to=""
      >
        Nazwa mapy
      </Link>
    </li>
  );
}

export default ListLink;
