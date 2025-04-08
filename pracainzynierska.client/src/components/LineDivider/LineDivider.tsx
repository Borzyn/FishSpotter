function LineDivider({
  color,
  height,
  margin,
}: {
  color: string;
  height: string;
  margin: string;
}) {
  return (
    <div
      aria-hidden="true"
      className={`w-full h-${height} ${color} my-${margin}`}
    ></div>
  );
}

export default LineDivider;
