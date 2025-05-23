import { useNavigate } from "react-router";
import { useModalStore } from "../../stores/useModalStore";
import { useUserStore } from "../../stores/useUserStore";

function ListButton({ fish, map }: { fish?: string; map?: string }) {
  const navigate = useNavigate();
  const { setModalStatus } = useModalStore();
  const { user } = useUserStore();

  function handleNavigate() {
    if (!user) {
      setModalStatus(true);
      return;
    }

    if (fish) {
      navigate(`/fish/${fish}`);
      return;
    }

    if (map) {
      navigate(`/map/${map}`);
      return;
    }
  }

  return (
    <li>
      <button
        onClick={handleNavigate}
        type="button"
        className="block w-full h-full cursor-pointer bg-sky-600 text-blue-50 hover:bg-sky-500 visited:bg-sky-600 active:bg-sky-600 text-center py-2 text-xl font-medium rounded-sm transition-colors duration-500"
      >
        {fish || map}
      </button>
    </li>
  );
}

export default ListButton;
