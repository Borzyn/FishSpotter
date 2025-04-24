export async function getFishMapApi(mapName?: string) {
  try {
    const res = await fetch(`/api/FishMain/ShowFishOnMap?mapName=${mapName}`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    });

    console.log(res);

    if (!res.ok) {
      const data = await res.json();
      console.log(data);
      throw new Error("Fish on map not found!");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
