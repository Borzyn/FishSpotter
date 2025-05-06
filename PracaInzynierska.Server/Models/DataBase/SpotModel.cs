using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class SpotModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string XY { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName = "varchar(36)")]
        public  string Map { get; set; }
    }
}
