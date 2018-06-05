using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("jwt")]
    public class Jwt
    {
        [Key]
        public int id { get; set; }
        public string token { get; set; }
    }
}

