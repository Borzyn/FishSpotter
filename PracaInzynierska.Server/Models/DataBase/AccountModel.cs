namespace FishSpotter.Server.Models.DataBase
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public double Score { get; set; }
        public int PostsCount { get; set; }
        public List<PostModel> Posts { get; set; }
        public string Password { get; set; }
    }
}
