import { createPortal } from "react-dom";

function Modal() {
  return createPortal(
    <>
      <div></div>
    </>,
    document.body
  );
}

export default Modal;
