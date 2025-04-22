export async function searchUserApi(accountCheckedName: string) {
  try {
    const res = await fetch(`/api/AccountModels/CheckProfile`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(accountCheckedName),
    });

    if (!res.ok) {
      throw new Error("User not found!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}

export async function searchFishApi(fishName: string) {
  try {
    const res = await fetch(`/api/FishMain/ShowFishMain`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(fishName),
    });

    if (!res.ok) {
      throw new Error("Fish not found!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
