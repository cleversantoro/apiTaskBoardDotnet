using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("token")]
    public class Token
    {
        [Key]
        public int id { get; set; }
        public string token { get; set; }
        public int user_id { get; set; }
    }
}

