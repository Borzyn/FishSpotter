import L, { LatLngBoundsExpression } from "leaflet";
import "leaflet/dist/leaflet.css";
import { useState } from "react";
import { ImageOverlay, MapContainer, Marker, Popup } from "react-leaflet";
import { useGetMapPoints } from "./useGetMapPoints";
import Loader from "../../components/Loaders/Loader/Loader";

const defaultIcon = new L.Icon({
  iconUrl:
    "https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-blue.png",
  shadowUrl:
    "https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png",
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  shadowSize: [41, 41],
});

const selectedIcon = new L.Icon({
  iconUrl:
    "https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png",
  shadowUrl:
    "https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png",
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  shadowSize: [41, 41],
});

function formatName(mapName: string) {
  if (!mapName) return;
  return mapName.toLowerCase().split(" ").join("_");
}

function Map({ mapName }: { mapName: string }) {
  const { data, isPending, isError } = useGetMapPoints(mapName);
  const [selectedMarker, setSelectedMarker] = useState(false);

  if (isPending) {
    return <Loader />;
  }

  if (isError || !data) {
    return null;
  }

  const imageWidth = 850;
  const imageHeight = 850;

  const bounds: LatLngBoundsExpression = [
    [0, 0],
    [imageHeight, imageWidth],
  ];

  const formattedMapName = formatName(mapName);

  console.log(data);

  return (
    <div>
      <MapContainer
        center={[imageHeight / 2, imageWidth / 2]}
        zoom={0}
        crs={L.CRS.Simple}
        style={{ height: imageHeight, width: imageWidth, margin: "0 auto" }}
        maxBounds={bounds}
        maxBoundsViscosity={1.0}
        keyboard={false}
        attributionControl={false}
      >
        <ImageOverlay url={`/${formattedMapName}.png`} bounds={bounds} />

        <Marker
          icon={selectedMarker ? selectedIcon : defaultIcon}
          position={[200, 200]}
          eventHandlers={{
            popupopen: () => setSelectedMarker(true),
            popupclose: () => setSelectedMarker(false),
          }}
        >
          <Popup>Współrzędne: [200, 200]</Popup>
        </Marker>
      </MapContainer>
    </div>
  );
}

export default Map;
