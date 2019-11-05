using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormModelExercise = Engineer.Models.Api.ExercisesDone.FormModel;

namespace Engineer.Models.Api.Training
{
    public class FormModel
    {
        public long TrainingPlanId { get; set; }
        public string Attention { get; set; }
        public List<FormModelExercise> ExercisesDone { get; set; }
    }
}
