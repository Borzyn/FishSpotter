namespace FishSpotter.Server.Models.AdditionalModels
{
    public class CreatePostModel
    {
        public string user { get; set; }
        public string fishname { get; set; }
        public string mapname { get; set; }
        public string methodname { get; set; }
        public string baitname { get; set; }
        public string groundbaitid { get; set; } = "none";
        public string spotXY { get; set; }
        public string addInfo { get; set; }




    }
}
