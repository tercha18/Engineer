using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engineer.Models.DataBase
{
    public class TrainingPlan
    {
        public TrainingPlan()
        {
            TrainingPlanExercises = new HashSet<TrainingPlanExercise>();
        }

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}
