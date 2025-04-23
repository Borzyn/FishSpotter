function Error({ error }: { error?: string }) {
  return (
    <div>
      <p className="text-center text-xl font-medium text-red-600">{error}</p>
    </div>
  );
}

export default Error;
