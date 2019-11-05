using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engineer.Models.DataBase;

namespace Engineer.Models.Api.Training
{
    public class ViewModel
    {
        public long Id { get; set; }
        public long TrainingPlanId { get; set; }
        public long UserId { get; set; }
        public string Attention { get; set; }
        public DateTime ExecutionTime { get; set; }
        public List<ExerciseDone> ExercisesDone { get; set; }
    }
}
