using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishSpotter.Server.Models.DataBase
{
    public class BaitModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(4)")]
        public double Size { get; set; }

        public List<MethodModel> Methods { get; set; } = new List<MethodModel>();
    }
}
