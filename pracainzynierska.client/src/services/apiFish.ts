import { IFishMapPosts } from "../features/AboutFish/useMapPostsNumber";

export async function getFishMapsApi(fishName: string) {
  try {
    const res = await fetch(`/api/FishMain/ShowFishMain`, {
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
    throw new Error("Fetching fish maps went wront");
  }
}

export async function getFishMapPostsNumberApi(dataFish: IFishMapPosts) {
  try {
    console.log(dataFish);

    const res = await fetch("/api/FishMain/ShowPostsWithFishAndMap", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(dataFish),
    });

    console.log(res);

    if (!res.ok) {
      const data = await res.json();
      console.log(data);
      throw new Error("Fetching fish maps went wrong!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error("Fetching fish maps went wront");
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
    const res = await fetch("/api/FishMain/ShowPostsWithFishAndMap", {
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
    throw new Error("Fetching fish maps went wront");
  }
}
