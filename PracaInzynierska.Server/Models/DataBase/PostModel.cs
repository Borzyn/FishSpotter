namespace FishSpotter.Server.Models.DataBase
{
    public class PostModel
    {
        public string Id { get; set; }
        public string userID { get; set; }
        public FishModel fish { get; set; }
        public double rate { get; set; }

    }
}
