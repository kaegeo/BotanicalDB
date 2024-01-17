using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public class FowlerPlantContext : IdentityDbContext<IdentityUser>
    {
        public FowlerPlantContext(DbContextOptions<FowlerPlantContext> options) : base(options)
        { }

        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<SpeciesComplex> SpeciesComplexes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    PlantId = 1,
                    PlantName = "Alocasia azlanii",
                    PlantType = "Species",
                    Synonym = "Red Mambo",
                    Distribution = "Indonesia",
                    ComplexId = 3,
                    AquiredDate = "September 2022",
                    PlantStatus = "Healthy"
                },
                new Plant
                {
                    PlantId = 2,
                    PlantName = "Alocasia heterophylla",
                    PlantType = "Species",
                    Synonym = "Dragon's Breath",
                    Distribution = "Philippines",
                    ComplexId = 4,
                    AquiredDate = "May 2023",
                    PlantStatus = "Healthy"
                },
                new Plant
                {
                    PlantId = 3,
                    PlantName = "Alocasia sanderiana",
                    PlantType = "Species",
                    Synonym = "Nobilis",
                    Distribution = "Philippines",
                    ComplexId = 5,
                    AquiredDate = "May 2023",
                    PlantStatus = "Healthy"
                }

                );

            modelBuilder.Entity<SpeciesComplex>().HasData(
                new SpeciesComplex
                {
                    ComplexId = 1,
                    ComplexName = "Undetermined"
                },
                new SpeciesComplex
                {
                    ComplexId = 2,
                    ComplexName = "Hybrid"
                },
                new SpeciesComplex
                {
                    ComplexId = 3,
                    ComplexName = "Cuprea group"
                },
                new SpeciesComplex
                {
                    ComplexId = 4,
                    ComplexName = "Heterophylla group"
                },
                new SpeciesComplex
                {
                    ComplexId = 5,
                    ComplexName = "Longiloba group"
                }
                );
        }
    }
}
