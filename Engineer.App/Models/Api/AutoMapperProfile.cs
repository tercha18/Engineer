using AutoMapper;
using Engineer.Models.Api.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Models.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() : this("")
        {
        }

        protected AutoMapperProfile(string profileName) : base(profileName)
        {
            UserMap();
            TrainingMap();
            ExerciseDoneMap();
            TrainingPlanMap();
            ExerciseMap();
        }

        #region UserMap()
        protected void UserMap()
        {
            CreateMap<Models.Api.User.ViewModel, Models.DataBase.User>()
                .ForMember(p => p.PasswordHash, o => o.Ignore())
                .ForMember(p => p.PasswordSalt, o => o.Ignore());

            CreateMap<Models.Api.User.FormModel, Models.DataBase.User>()
                .ForMember(p => p.PasswordHash, o => o.Ignore())
                .ForMember(p => p.PasswordSalt, o => o.Ignore())
                .ForMember(p => p.UserGoals, o => o.Ignore())
                .ForMember(p => p.UserMeasurements, o => o.Ignore())
                .ForMember(p => p.TrainingPlans, o => o.Ignore());

            CreateMap<Models.DataBase.User, Models.Api.User.FormModel>()
                .ForMember(p => p.Password, o => o.Ignore());
        }
        #endregion

        #region TrainigMap()
        protected void TrainingMap()
        {
            CreateMap<Models.Api.Training.ViewModel, Models.DataBase.Training>()
                .ForMember(p => p.TrainingPlan, o => o.Ignore())
                .ForMember(p => p.ExercisesDone, o => o.Ignore());

            CreateMap<Models.DataBase.Training, Models.Api.Training.FormModel>()
                .ForMember(p => p.ExercisesDone, o => o.Ignore());

            CreateMap<Models.Api.Training.FormModel, Models.DataBase.Training>()
                .ForMember(p => p.UserId, o => o.Ignore())
                .ForMember(p => p.ExecutionTime, o => o.Ignore())
                .ForMember(p => p.Id, o => o.Ignore())
                .ForMember(p => p.ExercisesDone, o => o.Ignore())
                .ForMember(p => p.TrainingPlan, o => o.Ignore());
        }
        #endregion

        #region ExerciseDoneMap()
        protected void ExerciseDoneMap()
        {
            CreateMap<ExercisesDone.FormModel, DataBase.ExerciseDone>()
                .ForMember(p => p.Training, o => o.Ignore())
                .ForMember(p => p.TrainingId, o => o.Ignore());

            //CreateMap<DataBase.ExerciseDone, ExerciseDone.FormModel>()
            //    .ForMember(p=> p.Length)
        }

        protected void TrainingPlanMap()
        {
            CreateMap<DataBase.TrainingPlan, TrainingPlan.FormModel>()
                .ForMember(p => p.ExerciseId, o => o.Ignore());

            CreateMap<TrainingPlan.FormModel, DataBase.TrainingPlan>()
                .ForMember(p => p.Trainings, o => o.Ignore())
                .ForMember(p => p.TrainingPlanExercises, o => o.Ignore())
                .ForMember(p => p.User, o => o.Ignore());
        }
        #endregion

        #region ExerciseMap()
        protected void ExerciseMap()
        {
            CreateMap<Exercise.FormModel, DataBase.Exercise>()
                .ForMember(p => p.Id, o => o.Ignore())
                .ForMember(p => p.TrainingPlanExercises, o => o.Ignore());
        }
        #endregion
    }
}
