import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Select from "react-select";
import FormRow from "../../components/FormRow/FormRow";
import Button from "../../components/Button/Button";
import { useCreatePost } from "./useCreatePost";
import Loader from "../../components/Loaders/Loader/Loader";
import useGetMapsAndMethods from "./useGetMapsAndMethods";
import Error from "../../components/Error/Error";
import { useUserStore } from "../../stores/useUserStore";

type OptionType = {
  value: string;
  label: string;
};

type OptionTypeSpots = {
  value: string;
  label: string;
  spots: {
    Id: string;
    XY: string;
  };
};

type SpotType = {
  XY: string;
  Id: string;
};

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full`;

const textareaStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full resize-y min-h-[100px]`;

type PostInputs = {
  mapname: string;
  fishname: string;
  methodname: string;
  baitname: string;
  addInfo: string;
  spotID: string;
};

function AddPost() {
  const { user } = useUserStore();
  const { isError, error, isPending, data } = useGetMapsAndMethods();

  const { isCreatingPost, createPost } = useCreatePost();
  const {
    register,
    handleSubmit,
    watch,
    resetField,
    reset,
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
    if (!user?.username) return;

    createPost(
      { user: user.username, ...data },
      {
        onError: () => reset(),
        onSuccess: () => reset(),
      }
    );
  };

  const findedMap = data?.maps.find(
    (map: OptionTypeSpots) => map.value === watch("mapname")
  );
  const spots = findedMap?.spots.map((spot: SpotType) => {
    return {
      value: spot.Id,
      label: spot.XY,
    };
  });

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
                  onChange={(selected) => {
                    resetField("spotID");
                    return field.onChange(selected?.value);
                  }}
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

          {spots && (
            <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
              <label
                htmlFor="spot"
                className="inline-block w-max tracking-wide text-slate-900"
              >
                Lokalizacja
              </label>
              <Controller
                name="spotID"
                control={control}
                rules={{ required: "Pole lokalizacji jest wymagane" }}
                render={({ field }) => (
                  <Select<OptionType>
                    className="basic-single"
                    classNamePrefix="select"
                    isClearable
                    isSearchable
                    inputId="spot"
                    options={spots}
                    value={
                      spots?.find(
                        (opt: OptionType) => opt.value === field.value
                      ) || null
                    }
                    onChange={(selected) => field.onChange(selected?.value)}
                    name={field.name}
                    ref={field.ref}
                  />
                )}
              />

              {errors.spotID?.message && (
                <p className="text-base text-red-500 font-semibold tracking-wider">
                  {errors.spotID.message}
                </p>
              )}
            </div>
          )}

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

          <FormRow label="Dodatkowe informacje" error={errors.addInfo?.message}>
            <textarea
              className={textareaStyles}
              id="addInfo"
              {...register("addInfo")}
            ></textarea>
          </FormRow>

          <p className="mt-6">
            <Button type="full" buttonType="submit" isDisable={isCreatingPost}>
              Dodaj Post
            </Button>
          </p>
        </>
      )}
    </form>
  );
}

export default AddPost;
