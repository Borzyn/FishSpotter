namespace FishSpotter.Server.Models.GameModels
{
    public class LocationModel
    {
        public string Name { get; set; }

        public FishModel Fish { get; set; }
        public int[] Coordinates { get; set; } = new int[2];
    }
}
