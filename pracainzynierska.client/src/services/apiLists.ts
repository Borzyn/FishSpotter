export async function getListMapsApi() {
  try {
    const res = await fetch("api/Home/ShowMaps", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    });
      console.log(res);
      if (!res.ok) {
          const error = await res.json();
          console.log(error);
      throw new Error("Fetching maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}

export async function getListFishApi() {
  try {
    const res = await fetch("api/Home/ShowFishes", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    });

    console.log(res);

    if (!res.ok) {
      throw new Error("Fetching fish went wrong!");
    }

    const data = await res.json();

    console.log(data);

    return data;
  } catch (error) {
    console.log(error);
    console.error();
  }
}
