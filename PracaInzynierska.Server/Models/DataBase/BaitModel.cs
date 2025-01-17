namespace FishSpotter.Server.Models.DataBase
{
    public class BaitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public List<MethodModel> Methods { get; set; }
    }
}
