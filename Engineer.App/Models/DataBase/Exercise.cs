using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Engineer.Models.DataBase
{
    public class Exercise
    { 
        public Exercise()
        {
            TrainingPlanExercises = new HashSet<TrainingPlanExercise>();
        }

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
    }
}
