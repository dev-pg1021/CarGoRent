using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CarGoRent.Entity
{
    public class Customer
    {

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Fname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Lname { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact must be in the format xxxxxxxxxx")]
        public string Contact { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$", ErrorMessage = "Password Must contain combination of number & character")]
        public string Password { get; set; }

        
    }
}
