export async function searchUserApi(accountCheckedName: string) {
  try {
    const res = await fetch(
      `api/AccountModels/CheckProfile/?accountCheckedName=${accountCheckedName}`,
      {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({}),
      }
    );

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
    const res = await fetch(`api/FishMain/ShowFishMain/?fishName=${fishName}`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify({}),
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
