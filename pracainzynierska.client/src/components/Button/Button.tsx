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
    classType =
      "cursor-pointer bg-sky-500 text-blue-50 text-lg font-semibold px-4 py-1 rounded-sm shadow-md transition-colors duration-500 shadow-slate-900/50 hover:bg-sky-600 active:bg-sky-700";
  } else if (type === "secondary") {
    classType = `bg-transparent text-2xl py-0.5 cursor-pointer border-2 border-sky-900 rounded-sm text-sky-900  font-semibold px-4 shadow-md  shadow-slate-900/50 transition-colors duration-500  hover:border-sky-800 active:bg-sky-900`;
  }

  return (
    <button type={buttonType} onClick={onClick} className={classType}>
      {children}
    </button>
  );
}

export default Button;
