using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class MethodModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        public List<string> BaitIds { get; set; }


        [ForeignKey(nameof(GroundBaitId))]
        public string GroundBaitId { get; set; }

        //public List<FishModel> Fish { get; set; }

        // public bool UseGroundbait { get; set; }

    }
}
