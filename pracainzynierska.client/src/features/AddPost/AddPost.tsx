import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Select from "react-select";
import FormRow from "../../components/FormRow/FormRow";
import Button from "../../components/Button/Button";

type OptionType = {
  value: string;
  label: string;
};

const dummyOptions: OptionType[] = [
  { value: "coffee1", label: "Coffee" },
  { value: "coffee2", label: "Coffee2" },
];

const inputStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full`;

const textareaStyles = `bg-white text-slate-900 placeholder:text-slate-400 border-2 border-blue-200 focus:border-sky-500 px-1.5 py-0.5 text-semibold rounded-[0.125rem] transition-all duration-500 outline-2 outline-offset-1 outline-transparent focus-within:outline-2 focus-within:outline-offset-1 focus-within:outline-amber-50 text-xl shadow-sm shadow-slate-900/50 w-full resize-y min-h-[100px]`;

type PostInputs = {
  map: string;
  fish: string;
  method: string;
  bait: string;
  additionalInformation: string;
  locationX: string;
  locationY: string;
};

function AddPost() {
  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<PostInputs>();

  const onSubmit: SubmitHandler<PostInputs> = (data) => {
    console.log(data);
  };

  return (
    <form className="max-w-2xl mx-auto" onSubmit={handleSubmit(onSubmit)}>
      <div className="flex flex-col justify-start gap-2 text-xl font-medium relative mb-3 last:mb-0">
        <label
          htmlFor="map"
          className="inline-block w-max tracking-wide text-slate-900"
        >
          Mapa
        </label>
        <Controller
          name="map"
          control={control}
          rules={{ required: "Pole mapy jest wymagane" }}
          render={({ field }) => (
            <Select<OptionType>
              className="basic-single"
              classNamePrefix="select"
              isClearable
              isSearchable
              inputId="map"
              options={dummyOptions}
              onChange={(selected) => field.onChange(selected?.value)}
              name={field.name}
              ref={field.ref}
            />
          )}
        />

        {errors.map?.message && (
          <p className="text-base text-red-500 font-semibold tracking-wider">
            {errors.map.message}
          </p>
        )}
      </div>

      <FormRow label="Ryba" error={errors.fish?.message}>
        <input
          className={inputStyles}
          type="text"
          id="fish"
          {...register("fish", { required: "Pole ryby musi być wpełnione" })}
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
          name="method"
          control={control}
          rules={{ required: "Pole metody jest wymagane" }}
          render={({ field }) => (
            <Select<OptionType>
              options={dummyOptions}
              className="basic-single"
              classNamePrefix="select"
              isClearable
              isSearchable
              inputId="method"
              onChange={(selected) => field.onChange(selected?.value)}
              name={field.name}
              ref={field.ref}
            />
          )}
        />

        {errors.method?.message && (
          <p className="text-base text-red-500 font-semibold tracking-wider">
            {errors.method.message}
          </p>
        )}
      </div>

      <FormRow label="Przynęta" error={errors.bait?.message}>
        <input
          className={inputStyles}
          type="text"
          id="bait"
          {...register("bait", {
            required: "Pole przynęty musi być wpełnione",
          })}
        />
      </FormRow>

      <FormRow
        label="Dodatkowe informacje"
        error={errors.additionalInformation?.message}
      >
        <textarea
          className={textareaStyles}
          id="additionalInformation"
          {...register("additionalInformation")}
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

      <Button type="primary" buttonType="submit">
        Dodaj Post
      </Button>
    </form>
  );
}

export default AddPost;
