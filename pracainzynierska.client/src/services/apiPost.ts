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
