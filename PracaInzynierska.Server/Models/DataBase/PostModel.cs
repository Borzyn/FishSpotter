using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishSpotter.Server.Models.DataBase
{
    public class PostModel
    {
        [Key]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; }

        // public FishModel fish { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName = "varchar(24)")]
        public string FishName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [Column(TypeName = "varchar(24)")]
        public string MapName { get; set; }

        [ForeignKey(nameof(SpotModel))]
        public string SpotID { get; set; }

        public SpotModel Spot { get; set; }

        //[ForeignKey(nameof(MethodModel))]
        //public string MethodName { get; set; }
        //public MethodModel Method { get; set; }

        [ForeignKey(nameof(BaitModel))]
        public string BaitId { get; set; }
        
        public BaitModel Bait { get; set; }

        
        //[ForeignKey(nameof(GroundbaitModel))]
        //public string groundbaitId { get; set; } = "0";
        //public GroundbaitModel groundbait { get; set; } 

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(24)")]
        public int rateSum { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(24)")]
        public int rateAmount { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(80)")]
        public string AdditionalInfo { get; set; } = null;

    }
}
