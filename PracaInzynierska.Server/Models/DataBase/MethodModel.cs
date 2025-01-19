using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class MethodModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }
   
        public List<FishModel> Fish { get; set; }
    
        public List<GroundbaitModel> Groundbait { get; set; }
      
        public List<BaitModel> Bait { get; set; }
    }
}
