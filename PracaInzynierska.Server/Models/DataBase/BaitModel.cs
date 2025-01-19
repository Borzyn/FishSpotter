using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishSpotter.Server.Models.DataBase
{
    public class BaitModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(5)")]
        public int Size { get; set; }

        public List<MethodModel> Methods { get; set; }
    }
}
