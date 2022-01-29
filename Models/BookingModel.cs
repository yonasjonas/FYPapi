using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BookingsModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string businessName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string date { get; set; }

        [Column(TypeName = "int")]
        public int businessId { get; set; }

        [Column(TypeName = "int")]
        public int serviceId { get; set; }

        

    }

}
