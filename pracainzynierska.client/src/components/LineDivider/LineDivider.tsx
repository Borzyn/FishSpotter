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
      className={`w-full ${height} ${color} ${margin}`}
    ></div>
  );
}

export default LineDivider;
