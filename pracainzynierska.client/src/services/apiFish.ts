export async function getFishMapsApi(fishName: string) {
  try {
    const res = await fetch("api/FishMain/ShowFishMain?fishName=${fishName}", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(fishName),
    });

    if (!res.ok) {
      throw new Error("Fetching fish maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}

export async function getFishMapPostsNumberApi({
  fishName,
  mapName,
}: {
  fishName: string;
  mapName: string;
}) {
  try {
    const res = await fetch("api/FishMain/ShowPostsWithFishAndMap", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify({ fishName, mapName }),
    });

    if (!res.ok) {
      throw new Error("Fetching fish maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}

export async function getFishMapPostsApi({
  fishName,
  mapName,
}: {
  fishName: string;
  mapName: string;
}) {
  try {
    const res = await fetch("api/FishMain/ShowPostsWithFishAndMap", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify({ fishName, mapName }),
    });

    if (!res.ok) {
      throw new Error("Fetching fish maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
  }
}
