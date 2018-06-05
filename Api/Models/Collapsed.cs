using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("collapsed")]
    public class Collapsed
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int lane_id { get; set; }
    }
}

