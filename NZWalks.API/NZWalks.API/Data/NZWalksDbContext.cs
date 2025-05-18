using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions) 
        {
        
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties
            //easy, medium, hard

            var difficuilties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("1deaf916-3f75-495b-9a7b-3cd0681cd4ba"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("1edb5943-90cb-4461-8d11-9664fb8bd1e9"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("061d8be5-2c5a-4f10-a49b-152d4e8f0a7a"),
                    Name = "Hard"
                }
            };

            // seed difficuilties to db
            modelBuilder.Entity<Difficulty>().HasData(difficuilties);



            // seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("0721538d-3198-4507-ac74-27ae4f5f53ee"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageURL = "akl.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("648f72ae-6b69-4c66-aa75-02952f84a7e4"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageURL = "bop.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("6a7ff25a-1813-4def-bd1c-4e9b8648a19d"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageURL = "wgn.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("280efda4-22be-4d4b-87f8-78770ab2e3fe"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageURL = "nsn.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("c2cb7c45-072a-4dcc-8abc-b7ef65e53abb"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageURL = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
