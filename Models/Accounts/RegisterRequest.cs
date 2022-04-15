using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public string BusinessName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string County { get; set; }
        public string Category { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}