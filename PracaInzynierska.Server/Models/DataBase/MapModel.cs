using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class MapModel
    {
        [Key]

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        public List<FishModel> Fishes { get; set; } = new List<FishModel>();

        public List<SpotModel> Spots { get; set; } = new List<SpotModel>();

    }
}
