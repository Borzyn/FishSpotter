import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Select from "react-select";
import FormRow from "../../components/FormRow/FormRow";
import Button from "../../components/Button/Button";
import { useCreatePost } from "./useCreatePost";
import Loader from "../../components/Loaders/Loader/Loader";
import useGetMapsAndMethods from "./useGetMapsAndMethods";
import Error from "../../components/Error/Error";

type OptionType = {
  value: string;
  label: string;
};

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full`;

const textareaStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full resize-y min-h-[100px]`;

type PostInputs = {
  mapname: string;
  fishname: string;
  methodname: string;
  baitname: string;
  groundbaitid: string;
  addInfo: string;
  locationX: string;
  locationY: string;
};

function AddPost() {
  const { isError, error, isPending, data } = useGetMapsAndMethods();

  console.log(data);

  const { isCreatingPost, createPost } = useCreatePost();
  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<PostInputs>();

  if (isPending) {
    return <Loader />;
  }

  if (isError) {
    return <Error error={error?.message} />;
  }

  const onSubmit: SubmitHandler<PostInputs> = (data) => {
    console.log(data);
  };

  return (
    <form className="max-w-2xl mx-auto" onSubmit={handleSubmit(onSubmit)}>
      {isCreatingPost ? (
        <Loader />
      ) : (
        <>
          <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
            <label
              htmlFor="map"
              className="inline-block w-max tracking-wide text-slate-900"
            >
              Mapa
            </label>
            <Controller
              name="mapname"
              control={control}
              rules={{ required: "Pole mapy jest wymagane" }}
              render={({ field }) => (
                <Select<OptionType>
                  className="basic-single"
                  classNamePrefix="select"
                  isClearable
                  isSearchable
                  inputId="mapname"
                  options={data?.maps}
                  onChange={(selected) => field.onChange(selected?.value)}
                  name={field.name}
                  ref={field.ref}
                />
              )}
            />

            {errors.mapname?.message && (
              <p className="text-base text-red-500 font-semibold tracking-wider">
                {errors.mapname.message}
              </p>
            )}
          </div>

          <FormRow label="Ryba" error={errors.fishname?.message}>
            <input
              className={inputStyles}
              type="text"
              id="fishname"
              {...register("fishname", {
                required: "Pole ryby musi być wpełnione",
              })}
            />
          </FormRow>

          <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
            <label
              htmlFor="method"
              className="inline-block w-max tracking-wide text-slate-900"
            >
              Metoda
            </label>
            <Controller
              name="methodname"
              control={control}
              rules={{ required: "Pole metody jest wymagane" }}
              render={({ field }) => (
                <Select<OptionType>
                  options={data?.methods}
                  className="basic-single"
                  classNamePrefix="select"
                  isClearable
                  isSearchable
                  inputId="methodname"
                  onChange={(selected) => field.onChange(selected?.value)}
                  name={field.name}
                  ref={field.ref}
                />
              )}
            />

            {errors.methodname?.message && (
              <p className="text-base text-red-500 font-semibold tracking-wider">
                {errors.methodname.message}
              </p>
            )}
          </div>

          <FormRow label="Przynęta" error={errors.baitname?.message}>
            <input
              className={inputStyles}
              type="text"
              id="baitname"
              {...register("baitname", {
                required: "Pole przynęty musi być wpełnione",
              })}
            />
          </FormRow>

          <FormRow label="Zanęta" error={errors.groundbaitid?.message}>
            <input
              className={inputStyles}
              type="text"
              id="groundbaitid"
              {...register("groundbaitid", {
                required: "Pole zanęty musi być wpełnione",
              })}
            />
          </FormRow>

          <FormRow label="Dodatkowe informacje" error={errors.addInfo?.message}>
            <textarea
              className={textareaStyles}
              id="addInfo"
              {...register("addInfo")}
            ></textarea>
          </FormRow>

          <div className="grid grid-cols-2 mb-4 gap-6">
            <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
              <label
                htmlFor="locationX"
                className="inline-block w-max tracking-wide text-slate-900"
              >
                Lokalizacja X
              </label>
              <input
                className={inputStyles}
                type="text"
                id="locationX"
                {...register("locationX", {
                  required: "Pole lokalizacji X musi być wpełnione",
                })}
              />
              {errors.locationX?.message && (
                <p className="text-base text-red-500 font-semibold tracking-wider">
                  {errors.locationX.message}
                </p>
              )}
            </div>
            <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
              <label
                htmlFor="locationY"
                className="inline-block w-max tracking-wide text-slate-900"
              >
                Lokalizacja Y
              </label>
              <input
                className={inputStyles}
                type="text"
                id="locationY"
                {...register("locationY", {
                  required: "Pole lokalizacji Y musi być wpełnione",
                })}
              />
              {errors.locationY?.message && (
                <p className="text-base text-red-500 font-semibold tracking-wider">
                  {errors.locationY.message}
                </p>
              )}
            </div>
          </div>

          <Button type="full" buttonType="submit" isDisable={isCreatingPost}>
            Dodaj Post
          </Button>
        </>
      )}
    </form>
  );
}

export default AddPost;
