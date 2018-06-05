using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int board_id { get; set; }
    }
}

