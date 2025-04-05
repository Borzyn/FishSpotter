import { SubmitHandler, useForm } from "react-hook-form";
import FormRow from "../../../components/FormRow/FormRow";
import { Eye, EyeOff } from "lucide-react";
import { useState } from "react";
import LineDivider from "../../../components/LineDivider/LineDivider";

interface IInputs {
  login: string;
  password: string;
}

const inputStyles = `bg-amber-50 text-stone-800 border-none px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl`;

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
            className="cursor-pointer absolute bottom-0.25 right-2 transition-colors duration-300 text-stone-800 hover:text-stone-500"
          >
            {showPassword ? <Eye size={28} /> : <EyeOff size={28} />}
          </button>
        </>
      </FormRow>

      <LineDivider />

      <div className="flex justify-between">
        <button
          onClick={toggleModal}
          type="button"
          className=" bg-amber-100  px-5 text-2xl py-1 rounded-sm cursor-pointer"
        >
          Back
        </button>

        <button
          type="submit"
          className=" bg-amber-100 px-5 text-2xl py-1 rounded-sm cursor-pointer"
        >
          Register
        </button>
      </div>
    </form>
  );
}

export default Register;
