using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishSpotter.Server.Models.DataBase
{
    public class FishModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        public List<MapModel> Maps { get; set; } /*= new List<MapModel>();*/
  
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
  
    }
}
