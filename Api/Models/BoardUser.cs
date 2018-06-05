using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("board_user")]
    public class BoardUser
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int board_id { get; set; }
    }
}

