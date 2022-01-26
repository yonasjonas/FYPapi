using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Account
    {

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
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