using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("board")]
    public class Board
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public int active { get; set; }
    }
}

