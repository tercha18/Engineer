using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Models.Api.ExercisesDone
{
    public class FormModel
    {
        public long ExerciseId { get; set; }
        public long Reps { get; set; }
        public long Weight { get; set; }
    }
}
