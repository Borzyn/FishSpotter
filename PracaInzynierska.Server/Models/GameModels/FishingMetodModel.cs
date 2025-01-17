namespace FishSpotter.Server.Models.GameModels
{
    public class FishingMetodModel
    {
        public string Name { get; set; }
        public int Clip { get; set; } = 0;
        public double Depth { get; set; } = 0;
        public int Speed { get; set; } = 0;
        public GroundbaitModel Groundbait { get; set; }
        public BaitModel[] Bait { get; set; }
        
    }
}
