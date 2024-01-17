using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public class Plant
    {
        // Set PlantId as primary key of Plant table
        [Key]
        public int PlantId { get; set; }

        // Set PlantName as required field
        [Required(ErrorMessage = "You must enter a plant name!")]
        public string PlantName { get; set; }

        // Set PlantType as required field
        [Required(ErrorMessage = "You must select a plant type!")]
        public string PlantType { get; set; }

        // Set Synonym as required field
        [Required(ErrorMessage = "You must enter a synonym or 'none'!")]
        public string Synonym { get; set; }

        // Set Distibution as required field
        [Required(ErrorMessage = "You must enter a distribution!")]
        public string Distribution { get; set; }

        // Set SpeciesComplex as required field
        [Required(ErrorMessage = "You must select a species complex!")]
        public int ComplexId { get; set; }

        [ValidateNever]
        public SpeciesComplex Complex { get; set; }

        // Set AquiredDate as required field
        [Required(ErrorMessage = "You must enter the date aquired!")]
        public string AquiredDate { get; set; }

        // Set PlantStatus as required field
        [Required(ErrorMessage = "You must select a plant status!")]
        public string PlantStatus { get; set; }
    }
}
