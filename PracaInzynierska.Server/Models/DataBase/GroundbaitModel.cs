namespace FishSpotter.Server.Models.DataBase
{
    public class GroundbaitModel
    {
        public string Id { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public List<MethodModel> Methods { get; set; }
    }
}
