using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Models.Api.TrainingPlan
{
    public class FormModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public List<long> ExerciseId { get; set; }
    }
}
