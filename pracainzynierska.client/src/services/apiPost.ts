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

    console.log(data);

    const maps = data.maps.map((map: { name: string }) => {
      return { label: map.name, value: map.name };
    });
    const methods = data.methods.map((method: { name: string }) => {
      return { label: method.name, value: method.name };
    });

    return { maps, methods };
  } catch (error) {
    console.error(error);
    throw new Error(error as string);
  }
}
