namespace FishSpotter.Server.Models.DataBase
{
    public class SpotModel
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AdditionalInfo { get; set; }
        public MapModel Map { get; set; }
    }
}
