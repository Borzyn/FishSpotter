namespace FishSpotter.Server.Models.DataBase
{
    public class MapModel
    {
        public String Name { get; set; }
        public List<String> Fishes { get; set; }
        public List<SpotModel> Spots { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
