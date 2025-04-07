import { Link } from "react-router";

function ListLink() {
  return (
    <li>
      <Link
        className="block w-full h-full cursor-pointer bg-red-700 text-center py-2 text-xl font-medium rounded-sm"
        to=""
      >
        Nazwa mapy
      </Link>
    </li>
  );
}

export default ListLink;
