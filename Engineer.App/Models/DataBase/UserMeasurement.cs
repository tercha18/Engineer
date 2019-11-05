using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engineer.Models.DataBase
{
    public class UserMeasurement
    {
        [Key]
        public long Id { get; set; }
        public int Type { get; set; }
        public long Value { get; set; }

        public User User { get; set; }
    }
}
