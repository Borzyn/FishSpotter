namespace FishSpotter.Server.Models.GameModels
{
    public class PostModel
    {
        public string Id { get; set; }
        public string creatorId { get; set; }
        public string fish {  get; set; }
        public string map {  get; set; }
        public string coordinates { get; set; }
        public string method { get; set; }
        public string bait { get; set; }
        public string groundbait1 { get; set; }
        public string groundbait2 { get; set; }
        public string groundbait3 { get; set; }
        public string groundbait4 { get; set; }
        public string groundbait5 { get; set; }
        public int additionalInfo { get; set; }
        
    }
}
