using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BusinessModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string businessName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string locationName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string businessCategory { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string imagePath { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string priceRange { get; set; }

    }

}
