using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamApacheProjekatBackend.Models
{
    public class Attachment
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        [NotMapped]
        public required IFormFile Files { get; set; }
    }
}
