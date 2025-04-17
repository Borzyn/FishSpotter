import { SubmitHandler, useForm } from "react-hook-form";
import FormRow from "../../../components/FormRow/FormRow";
import { Eye, EyeOff } from "lucide-react";
import { useState } from "react";
import LineDivider from "../../../components/LineDivider/LineDivider";
import { useRegister } from "../useRegister";

interface IInputs {
  login: string;
  password: string;
  confirm_password: string;
  terms_accept: boolean;
}

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50`;

function Register({ toggleModal }: { toggleModal: () => void }) {
  const { isCreatingAccount, createAccount } = useRegister();
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<IInputs>();

  const [showPassword, setShowPassword] = useState<boolean>(false);
  const [showPasswordConfirmation, setShowPasswordConfirmation] =
    useState<boolean>(false);

  const onSubmit: SubmitHandler<IInputs> = (data) => {
    createAccount(
      {
        username: data.login,
        password: data.password,
        passwordConfirmed: data.confirm_password,
        termsAccept: data.terms_accept,
      },
      {
        onSuccess: () => {
          console.log("Git");
          toggleModal();
        },
        onError: () => {
          reset();
        },
      }
    );
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

      <FormRow
        label="Confirm Password"
        inputId="confirm_password"
        error={errors.confirm_password?.message as string}
      >
        <>
          <input
            type={`${showPasswordConfirmation ? "text" : "password"}`}
            className={`${inputStyles} pr-11`}
            id="confirm_password"
            {...register("confirm_password", {
              required: "Password Confirmation field is required",
            })}
          />
          <button
            type="button"
            onClick={() =>
              setShowPasswordConfirmation(!showPasswordConfirmation)
            }
            className="cursor-pointer absolute bottom-0.75 right-2 transition-colors duration-500 text-slate-900 hover:text-sky-500"
          >
            {showPasswordConfirmation ? (
              <Eye size={28} />
            ) : (
              <EyeOff size={28} />
            )}
          </button>
        </>
      </FormRow>

      <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3">
        <label className="flex items-center" htmlFor="terms_accept">
          <input
            className="relative peershrink-0 mt-0.5 appearance-none w-5 h-5 border-2 border-blue-500 rounded-sm bg-white checked:bg-blue-800 checked:border-0 focus:outline-none focus:ring-offset-0 focus:ring-2 focus:ring-blue-100 disabled:border-steel-400 disabled:bg-steel-400 mr-2"
            id="terms_accept"
            type="checkbox"
            {...register("terms_accept", {
              required: "You must accept terms",
            })}
          />
          I understand and accept all terms
        </label>
        {errors.terms_accept && (
          <p className="text-base text-red-500 font-semibold tracking-wider">
            {errors.terms_accept.message}
          </p>
        )}
      </div>

      <LineDivider color="bg-slate-900" margin="my-3.5" height="h-0.5" />

      <div className="flex justify-between">
        <button
          onClick={toggleModal}
          type="button"
          disabled={isCreatingAccount}
          className="bg-transparent text-2xl py-0.5 cursor-pointer border-2 border-sky-900 rounded-sm text-sky-900  font-semibold px-4 shadow-md  shadow-slate-900/50 transition-colors duration-500 hover:bg-sky-800 hover:text-blue-50 active:bg-sky-900 active:text-blue-50 hover:border-sky-800 active:border-sky-900"
        >
          Back
        </button>

        <button
          disabled={isCreatingAccount}
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
