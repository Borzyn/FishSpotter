using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class GroundbaitModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string GBName { get; set; }

        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();

        //public List<MethodModel> Methods { get; set; } = new List<MethodModel> { };
    }
}
