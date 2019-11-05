using Engineer.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormModelExercise = Engineer.Models.Api.Exercise.FormModel;

namespace Engineer.Models.Api.TrainingPlan
{
    public class ViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public List<FormModelExercise> Exercises { get; set; }
    }
}
