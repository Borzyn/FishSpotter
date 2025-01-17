namespace FishSpotter.Server.Models.GameModels
{
    public class GroundbaitModel
    {
        public string Base{ get; set; }
        public string[] Ingredients { get; set; } = new string[4];
        public string Attractor { get; set; }
    }
}
