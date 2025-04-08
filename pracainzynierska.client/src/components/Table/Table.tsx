function Table({ tableHeaders, tableCells }: { tableHeaders: string[] }) {
  return (
    <div className="w-full overflow-auto">
      <div className="min-w-6xl overflow-hidden">
        <table className="m-auto text-center grid grid-cols-1 rounded-sm overflow-auto">
          <thead>
            <tr className="grid grid-cols-6 text-xl py-3">
              {tableHeaders.map((name: string, index: number) => (
                <th key={index} className="">
                  {name}
                </th>
              ))}
            </tr>
          </thead>

          <tbody>
            <tr className="grid grid-cols-6 text-lg font-medium py-3">
              <td>Pond</td>
              <td>4</td>
              <td>4</td>
              <td>4</td>
              <td>4</td>
              <td>4</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default Table;
