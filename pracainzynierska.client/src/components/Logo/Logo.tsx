import { Link } from "react-router";

function Logo() {
  return (
    <Link to="/">
      <img src="/logo.png" alt="fishspotter logo" />
    </Link>
  );
}

export default Logo;
