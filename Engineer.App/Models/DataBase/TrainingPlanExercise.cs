using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Engineer.Models.DataBase
{
    public class TrainingPlanExercise
    {
        [Key]
        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long ExerciseId { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
        public Exercise Exercise { get; set; }
    }
}
