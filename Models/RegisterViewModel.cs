using System.ComponentModel.DataAnnotations;

namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Must enter a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must enter a password")]
        [Compare("ConfirmPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool KeepLogin { get; set; }
    }
}
