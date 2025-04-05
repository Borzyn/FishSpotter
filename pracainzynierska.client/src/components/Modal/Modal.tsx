import { ReactElement } from "react";
import { createPortal } from "react-dom";

function Modal({
  children,
  onClick,
}: {
  children: ReactElement;
  onClick: () => void;
}) {
  return createPortal(
    <>
      <div
        className="absolute cursor-pointer top-0 left-0 w-full h-full bg-stone-800/70"
        onClick={onClick}
      ></div>
      <div className="bg-red-200 p-5 rounded-sm absolute top-6/12 left-6/12 -translate-6/12 ">
        {children}
      </div>
    </>,
    document.body
  );
}

export default Modal;
