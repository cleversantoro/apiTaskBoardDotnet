using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("activity")]
    public class Activity
    {
        [Key]
        public int id { get; set; }

        public int item_id { get; set; }

        public string comment { get; set; }

        public string old_value { get; set; }

        public string new_value { get; set; }

        public int timestamp { get; set; }
    }
}

