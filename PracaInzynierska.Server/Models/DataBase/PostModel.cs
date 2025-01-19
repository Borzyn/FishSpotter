using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class PostModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string userID { get; set; }
       
        public FishModel fish { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(8)")]
        public double rate { get; set; }

    }
}
