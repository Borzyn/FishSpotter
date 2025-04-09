import Table from "../../components/Table/Table";

const tableHeaders = [
  "Autor",
  "Metoda",
  "Przynęta",
  "Dodatkowe",
  "Ocena",
  "Mapa",
];

function FishMapPage() {
  return (
    <section className="w-full h-full">
      <div className="w-full max-h-80 min-h-80 h-full bg-amber-200">Map</div>
      <div className="mt-6 text-center">
        <p className="text-lg font-medium">Ryba</p>
        <p className="text-3xl font-semibold">Łosoś</p>
      </div>

      <div className="mt-6 mb-10 text-center">
        <p className="text-lg font-medium">Łowisko</p>
        <p className="text-3xl font-semibold">Nazwa łowsika</p>
      </div>

      <Table tableHeaders={tableHeaders} />
    </section>
  );
}

export default FishMapPage;
