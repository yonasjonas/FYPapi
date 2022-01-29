using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class WidgetModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string name { get; set; }

        public string businessID { get; set; }
        
       

    }

}
