using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class MapModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public String Name { get; set; }

        public List<String> Fishes { get; set; }

        public List<SpotModel> Spots { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(4)")]
        public int X { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(4)")]
        public int Y { get; set; }
    }
}
