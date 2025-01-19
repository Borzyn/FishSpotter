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
        [Column(TypeName = "varchar(4)")]
        public int X { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(4)")]
        public int Y { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(4)")]
        public int AdditionalInfo { get; set; }

        public MapModel Map { get; set; }
    }
}
