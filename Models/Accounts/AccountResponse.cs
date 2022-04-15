using Microsoft.AspNetCore.Http;
using System;

namespace WebApi.Models.Accounts
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
    }
}