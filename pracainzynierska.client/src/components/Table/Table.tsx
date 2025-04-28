import { IPost } from "../../stores/useUserStore";

function Table({
  tableHeaders,
  //tableCells,
  title,
}: {
  tableHeaders: string[];
  tableCells: IPost[];
  title?: string;
}) {
  return (
    <div className="w-full overflow-auto">
      {title && (
        <h2 className="text-3xl block font-bold text-center py-3 mb-1.5">
          {title}
        </h2>
      )}
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
