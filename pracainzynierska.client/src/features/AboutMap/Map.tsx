import "leaflet/dist/leaflet.css";
import { ImageOverlay, MapContainer } from "react-leaflet";

function Map() {
  return (
    <div className="w-full h-150">
      <MapContainer center={[400, 500]} zoom={0} style={{ height: "100%" }}>
        <ImageOverlay
          url=""
          bounds={[
            [0, 0],
            [800, 1000],
          ]}
        />
      </MapContainer>
    </div>
  );
}

export default Map;
