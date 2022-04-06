﻿using System;
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

        [Column(TypeName = "int")]
        public int BusinessId { get; set; }

        [Column(TypeName = "int")]
        public int ServiceId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int ServiceName { get; set; }

        [Column(TypeName = "int")]
        public int ProviderId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int ProviderName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string BookingStartTime { get; set; }

        [Column(TypeName = "int")]
        public int BookingDuration { get; set; }

        

    }

}
