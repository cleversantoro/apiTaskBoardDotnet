using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("[user]")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public bool is_admin { get; set; }
        public int logins { get; set; }
        public int last_login { get; set; }
        public int default_board { get; set; }
        public string salt { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}

