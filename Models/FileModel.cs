using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class FileModel
    {
        internal object[] businessId;

        [Key]
        public int Id { get; set; }
        [Required]
        public int BusinessId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string FileName { get; set; }

        [Required]
        [NotMappedAttribute]
        public IFormFile FormFile  { get; set; }

    }

}
