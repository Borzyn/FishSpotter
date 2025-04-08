function FishPage() {
  return (
    <section className="w-full h-full">
      <table className="m-auto min-w-80 text-center grid grid-cols-1 rounded-sm overflow-hidden">
        <tr className="">
          <th className="text-2xl block font-bold text-center py-3" colSpan={2}>
            Fish Name
          </th>
        </tr>
        <tr className="grid grid-cols-2 text-xl py-3">
          <th>Maps</th>
          <th>Number of Posts</th>
        </tr>
        <tr className="grid grid-cols-2 text-lg font-medium py-3">
          <td>Pond</td>
          <td>4</td>
        </tr>

        <tr className="grid grid-cols-2 text-lg font-medium py-3">
          <td>Pond</td>
          <td>4</td>
        </tr>

        <tr className="grid grid-cols-2 text-lg font-medium py-3">
          <td>Pond</td>
          <td>4</td>
        </tr>
      </table>
    </section>
  );
}

export default FishPage;
