export async function getAccountInformationsApi(accountCheckedName: string) {
  try {
    const res = await fetch("api/AccountModels/CheckProfile", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(accountCheckedName),
    });

    if (!res.ok) {
      throw new Error("Fetching maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}

export async function getAccountPostsApi(accountName: string) {
  try {
    const res = await fetch("api/AccountModels/ShowPosts", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(accountName),
    });

    if (!res.ok) {
      throw new Error("Fetching maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}
