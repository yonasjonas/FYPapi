using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WebApi.Models
{
    public class BusinessInfoModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string BusinessName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Address1 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Address2 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string County { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Category { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public bool IsVerified { get; set; }
    }
}
