using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Model
{
    [Table("user")]
    public class User
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string createUser { get; set; }
        public DateTime? createDate { get; set; }
        public string statusType { get; set; }
    }
}
