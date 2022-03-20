using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BusinessServiceModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string serviceName { get; set; }

        public int price { get; set; }

        public int timeSlotDuration { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string weekvalue { get; set; }

        public int businessId { get; set; }

        public string providerId { get; set; }

    }

}
