namespace FishSpotter.Server.Models.DataBase
{
    public class MethodModel
    {
        public string Name { get; set; }
        public List<FishModel> Fish { get; set; }
        public List<GroundbaitModel> Groundbait { get; set; }
        public List<BaitModel> Bait { get; set; }
    }
}
