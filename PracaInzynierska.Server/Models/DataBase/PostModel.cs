﻿using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "varchar(24)")]
        public string FishName { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(24)")]
        public string MapName { get; set; }

        public SpotModel Spot { get; set; }

        public MethodModel Method { get; set; }

        [ForeignKey(nameof(BaitModel))]
        public string BaitId { get; set; }
        public BaitModel Bait { get; set; }


        [ForeignKey(nameof(GroundbaitModel))]
        public string groundbaitId { get; set; }
        public GroundbaitModel groundbait { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(24)")]
        public int rateSum { get; set; }

        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(24)")]
        public int rateAmount { get; set; }

    }
}
