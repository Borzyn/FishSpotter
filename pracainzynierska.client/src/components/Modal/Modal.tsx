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
        className="fixed cursor-pointer top-0 left-0 w-full h-full bg-slate-900/60"
        onClick={onClick}
      ></div>
      <div className="bg-white p-5 rounded-sm fixed top-6/12 left-6/12 -translate-6/12 border-blue-100 border-4 shadow-md shadow-slate-900 sm:max-w-[420px] sm:w-full">
        {children}
      </div>
    </>,
    document.body
  );
}

export default Modal;
