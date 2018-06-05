using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("option")]
    public class Option
    {
        [Key]
        public int id { get; set; }
        public int tasks_order { get; set; }
        public int show_animations { get; set; }
        public int show_assignee { get; set; }
        public int user_id { get; set; }

    }
}

