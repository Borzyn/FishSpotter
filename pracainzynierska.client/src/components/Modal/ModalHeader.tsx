import { X } from "lucide-react";

function ModalHeader({
  title,
  onClick,
}: {
  title: string;
  onClick: () => void;
}) {
  return (
    <>
      <h2 className="text-center text-2xl px-4">{title}</h2>
      <button
        onClick={onClick}
        className="cursor-pointer absolute right-2 top-2"
      >
        <X size={28} />
      </button>
    </>
  );
}

export default ModalHeader;
