export async function getFishMapApi(mapName?: string) {
  try {
    const res = await fetch(`/api/FishMain/ShowFishOnMap?mapName=${mapName}`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    });

    if (!res.ok) {
      throw new Error("Fish on map not found!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}

export async function getFishMapPostsApi(fishName: string, mapName: string) {
  try {
    const res = await fetch(
      `/api/Map/GetPostsMapWithFish?fishName=${fishName}&mapName=${mapName}`,
      {
        headers: {
          "Content-Type": "application/json",
        },
        method: "GET",
      }
    );

    if (!res.ok) {
      throw new Error("Fish on map not found!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}

export async function getPostRateApi(username: string, postId: string) {
  const res = await fetch(
    `/api/Post/RateCheck?PostID=${postId}&username=${username}`,
    {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    }
  );

  if (!res.ok) {
    return null;
  }

  const data = await res.json();
  return data.rate;
}

export async function setPostRateApi(postData: {
  user: string;
  postId: string;
  rate: number;
}) {
  try {
    const res = await fetch(`/api/Post/Rate`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(postData),
    });

    if (!res.ok) {
      throw new Error("Something went wrong with rating");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
