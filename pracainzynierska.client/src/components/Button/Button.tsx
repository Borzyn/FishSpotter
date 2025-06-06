import { ReactElement } from "react";

let classType = "";

interface IButton {
  children: ReactElement | string;
  buttonType: "button" | "submit" | "reset";
  type: string;
  onClick?: () => void;
  isDisable?: boolean;
}

function Button({ children, buttonType, type, onClick, isDisable }: IButton) {
  if (type === "primary") {
    classType =
      "cursor-pointer bg-sky-500 text-blue-50 text-lg font-semibold px-4 py-1 rounded-sm shadow-md transition-colors duration-500 shadow-slate-900/50 hover:bg-sky-600 active:bg-sky-700 lg:text-xl";
  } else if (type === "secondary") {
    classType = `bg-transparent text-2xl py-0.5 cursor-pointer border-2 border-sky-900 rounded-sm text-sky-900  font-semibold px-4 shadow-md  shadow-slate-900/50 transition-colors duration-500  hover:border-sky-800 active:bg-sky-900 lg:text-xl`;
  } else if (type === "full") {
    classType = `cursor-pointer bg-sky-500 text-blue-50 text-2xl font-semibold px-4 py-2.5 rounded-sm shadow-md transition-colors duration-500 shadow-slate-900/50 hover:bg-sky-600 active:bg-sky-700 lg:text-2xl w-full`;
  }

  return (
    <button
      disabled={isDisable}
      type={buttonType}
      onClick={onClick}
      className={classType}
    >
      {children}
    </button>
  );
}

export default Button;
