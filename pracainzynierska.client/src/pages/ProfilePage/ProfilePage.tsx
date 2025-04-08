import Table from "../../components/Table/Table";

const tableHeaders = [
  "Ryba",
  "Łowisko",
  "Metoda",
  "Ocena",
  "Lokalizacja",
  "Odnośnik",
];

function ProfilePage() {
  return (
    <section className="w-full h-full">
      <div className="flex gap-5 flex-col items-center mb-8.5">
        <div className="flex gap-1 flex-col justify-center items-center">
          <h3 className="text-xl ">Ilość postów</h3>
          <p className="text-4xl font-semibold">423</p>
        </div>
        <div className="flex gap-1 flex-col justify-center items-center">
          <h3 className="text-xl ">Średnia ocena postów</h3>
          <p className=" text-4xl font-semibold">4,43</p>
        </div>
      </div>

      <Table tableHeaders={tableHeaders} />
    </section>
  );
}

export default ProfilePage;
