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
      <h2 className="text-center text-3xl font-semibold tracking-wide text-slate-900 px-4">
        {title}
      </h2>
      <button
        onClick={onClick}
        className="cursor-pointer absolute right-2 top-2 transition-colors duration-500 text-slate-900 hover:text-sky-500"
      >
        <X size={28} />
      </button>
    </>
  );
}

export default ModalHeader;
