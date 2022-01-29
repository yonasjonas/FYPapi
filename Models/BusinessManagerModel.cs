using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BusinessManagerModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string password { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string activated { get; set; }

        [Column(TypeName = "int")]
        public int serviceId { get; set; }

    }

}
