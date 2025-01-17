using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FishSpotter.Server.Models.DataBase;

namespace FishSpotter.Server.Data
{
    public class FishSpotterServerContext : DbContext
    {
        public FishSpotterServerContext (DbContextOptions<FishSpotterServerContext> options)
            : base(options)
        {
        }

        public DbSet<FishSpotter.Server.Models.DataBase.AccountModel> AccountModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.FishModel> FishModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.MapModel> MapModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.BaitModel> BaitModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.GroundbaitModel> GroundbaitModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.IngredientModel> IngredientModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.MethodModel> MethodModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.PostModel> PostModel { get; set; } = default!;
        public DbSet<FishSpotter.Server.Models.DataBase.SpotModel> SpotModel { get; set; } = default!;

    }
}
