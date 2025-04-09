import { SubmitHandler, useForm } from "react-hook-form";
import FormRow from "../../../components/FormRow/FormRow";
import { Eye, EyeOff } from "lucide-react";
import { useState } from "react";
import LineDivider from "../../../components/LineDivider/LineDivider";

interface IInputs {
  login: string;
  password: string;
}

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50`;

function Register({ toggleModal }: { toggleModal: () => void }) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IInputs>();

  const [showPassword, setShowPassword] = useState<boolean>(false);

  const onSubmit: SubmitHandler<IInputs> = (data) => console.log(data);

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <FormRow label="Login" error={errors.login?.message as string}>
        <input
          type="text"
          className={inputStyles}
          id="login"
          {...register("login", {
            required: "Login field is required",
          })}
        />
      </FormRow>

      <FormRow
        label="Password"
        inputId="password"
        error={errors.password?.message as string}
      >
        <>
          <input
            type={`${showPassword ? "text" : "password"}`}
            className={`${inputStyles} pr-11`}
            id="password"
            {...register("password", {
              required: "Password field is required",
            })}
          />
          <button
            type="button"
            onClick={() => setShowPassword(!showPassword)}
            className="cursor-pointer absolute bottom-0.75 right-2 transition-colors duration-500 text-slate-900 hover:text-sky-500"
          >
            {showPassword ? <Eye size={28} /> : <EyeOff size={28} />}
          </button>
        </>
      </FormRow>

      <LineDivider color="bg-slate-900" margin="my-3.5" height="h-0.5" />

      <div className="flex justify-between">
        <button
          onClick={toggleModal}
          type="button"
          className="bg-transparent text-2xl py-0.5 cursor-pointer border-2 border-sky-900 rounded-sm text-sky-900  font-semibold px-4 shadow-md  shadow-slate-900/50 transition-colors duration-500 hover:bg-sky-800 hover:text-blue-50 active:bg-sky-900 active:text-blue-50 hover:border-sky-800 active:border-sky-900"
        >
          Back
        </button>

        <button
          type="submit"
          className=" bg-sky-500 text-2xl py-1 rounded-sm cursor-pointer text-blue-50  font-semibold px-4  shadow-md transition-colors duration-500 shadow-slate-900/50 hover:bg-sky-600 active:bg-sky-700"
        >
          Register
        </button>
      </div>
    </form>
  );
}

export default Register;
