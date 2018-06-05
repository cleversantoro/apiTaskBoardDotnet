using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("lane")]
    public class Lane
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public int board_id { get; set; }
    }
}

