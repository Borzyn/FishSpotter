import { ReactElement } from "react";

let classType = "";

interface IButton {
  children: ReactElement | string;
  buttonType: "button" | "submit" | "reset";
  type: string;
  onClick: () => void;
}

function Button({ children, buttonType, type, onClick }: IButton) {
  if (type === "primary") {
    classType = "";
  }

  return (
    <button
      type={buttonType}
      onClick={onClick}
      className="cursor-pointer bg-teal-400 text-lg font-semibold px-4 py-1 rounded-sm"
    >
      {children}
    </button>
  );
}

export default Button;
