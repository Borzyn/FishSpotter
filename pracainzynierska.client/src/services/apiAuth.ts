import { ILoginData } from "../features/Authentication/useLogin";
import { IRegisterData } from "../features/Authentication/useRegister";

export async function loginToAccountApi(accountData: ILoginData) {
  try {
    const res = await fetch("api/AccountModels/Login", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(accountData),
    });

    if (!res.ok) {
      const error = await res.json();
      console.log(error);
      throw new Error("Invalid credentials");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}

export async function createAccountApi(accountData: IRegisterData) {
  try {
    const res = await fetch("api/AccountModels/registerCheck", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(accountData),
    });

    if (!res.ok) {
      throw new Error("Creating account went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
