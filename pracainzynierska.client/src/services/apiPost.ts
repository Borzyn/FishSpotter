import { ICreatePost } from "../features/AddPost/useCreatePost";

export async function createPostApi(postData: ICreatePost) {
  try {
    const res = await fetch("/api/Post/Create", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(postData),
    });

    if (!res.ok) {
      throw new Error("Invalid credentials");
    }

    const data = await res.json();

    return data;
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}

export async function getMapsAndMethodsApi() {
  try {
    const res = await fetch(`/api/Post/StartCreatingPost`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "GET",
    });

    if (!res.ok) {
      throw new Error("Something went wrong with fetching maps and methods");
    }

    const data = await res.json();

    const maps = data.maps.map(
      (map: { Name: string; Spots: { Id: string; XY: string }[] }) => {
        return { label: map.Name, value: map.Name, spots: [...map.Spots] };
      }
    );
    const methods = data.methods.map((method: { Name: string }) => {
      return { label: method.Name, value: method.Name };
    });

    return { maps, methods };
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
