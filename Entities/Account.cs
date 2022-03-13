using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Account
    {

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BusinessName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Phone { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address1 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address2 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string County { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Country { get; set; }
        public string PasswordHash { get; set; }

        public bool AcceptTerms { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public Role Role { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string VerificationToken { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;

        [Column(TypeName = "nvarchar(250)")]
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}

/*
 [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BusinessName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string profileImagePath { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string coverImagePath { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string address1 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string address2 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string county { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string country { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }        

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
 */