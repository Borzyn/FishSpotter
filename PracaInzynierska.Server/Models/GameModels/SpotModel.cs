namespace FishSpotter.Server.Models.GameModels
{
    public class SpotModel
    {
        public string SpotID { get; set; }
        public FishModel Fish { get; set; }
        public LocationModel Location { get; set; }
        public int[] Coordinates { get; set; } = new int[2];
        //Including Bait, Groundbait and parameters related with every fishing metod
        public FishingMetodModel FishingMetod { get; set; }
        

    }
}
