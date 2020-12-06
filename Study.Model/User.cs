using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Model
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}
