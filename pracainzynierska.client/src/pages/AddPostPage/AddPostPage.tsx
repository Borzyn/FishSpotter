import AddPost from "../../features/AddPost/AddPost";

function AddPostPage() {
  return (
    <section className="w-full h-full mx-auto max-w-7xl">
      <h1 className="text-center text-4xl font-medium mb-6">Dodaj Post</h1>
      <AddPost />
    </section>
  );
}

export default AddPostPage;
