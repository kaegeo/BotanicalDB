using System.ComponentModel.DataAnnotations;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public class SpeciesComplex
    {
        // Set ComplexId as primary key for SpeciesComplex table
        [Key]
        public int ComplexId { get; set; }

        // Set ComplexName as required field
        [Required(ErrorMessage = "You must enter a species complex name!")]
        public string ComplexName { get; set; }
    }
}
