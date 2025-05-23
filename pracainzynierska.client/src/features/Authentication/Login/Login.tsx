import { SubmitHandler, useForm } from "react-hook-form";
import FormRow from "../../../components/FormRow/FormRow";
import { Eye, EyeOff } from "lucide-react";
import { useState } from "react";
import LineDivider from "../../../components/LineDivider/LineDivider";
import { useLogin } from "../useLogin";
import { useModalStore } from "../../../stores/useModalStore";

interface IInputs {
  login: string;
  password: string;
}

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full`;

function Login({ toggleModal }: { toggleModal: () => void }) {
  const { isLoggingToAccount, loginToAccount } = useLogin();
  const { setModalStatus } = useModalStore();

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<IInputs>();

  const [showPassword, setShowPassword] = useState<boolean>(false);

  const onSubmit: SubmitHandler<IInputs> = (data) => {
    loginToAccount(data, {
      onSuccess: () => {
        setModalStatus(false);
      },
      onError: () => {
        reset();
      },
    });
  };

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
        <div className="relative">
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
        </div>
      </FormRow>

      <LineDivider color="bg-slate-900" margin="my-3.5" height="h-0.5" />

      <button
        type="submit"
        disabled={isLoggingToAccount}
        className="w-full cursor-pointer bg-sky-500 text-2xl py-1 rounded-sm text-blue-50  font-semibold px-4  shadow-md transition-colors duration-500 shadow-slate-900/50 hover:bg-sky-600 active:bg-sky-700"
      >
        Login
      </button>

      <div className="flex justify-center">
        <button
          type="button"
          disabled={isLoggingToAccount}
          onClick={toggleModal}
          className="mx-auto text-center underline cursor-pointer mt-4 transition-colors duration-300 text-sky-500 hover:text-sky-600 visited:text-sky-600 active:text-sky-700"
        >
          You don't have account? Register now!
        </button>
      </div>
    </form>
  );
}

export default Login;
