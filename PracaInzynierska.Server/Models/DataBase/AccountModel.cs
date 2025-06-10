using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishSpotter.Server.Models.DataBase
{
    public class AccountModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(32)")]
        public string Username { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(10)")]
        public int RateSum { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(10)")]
        public int RateAmount { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(8)")]
        public int PostsCount { get; set; }

        public List<PostModel> Posts { get; set; } = new List<PostModel>();

        [Required]
        [DataType(DataType.Password)]
        [Column(TypeName = "varchar(32)")]
        public string Password { get; set; }

    }
}
