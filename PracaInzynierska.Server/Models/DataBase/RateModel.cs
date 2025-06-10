using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishSpotter.Server.Models.DataBase
{
    public class  RateModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(32)")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string PostId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(5)")]
        public int Rate { get; set; }
    }
}
