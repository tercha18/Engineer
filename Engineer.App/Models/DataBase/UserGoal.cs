using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engineer.Models.DataBase
{
    public class UserGoal
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public User User { get; set; }
    }
}
