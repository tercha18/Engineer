using AutoMapper;
using Engineer.Data;
using Engineer.Models.Api.ExercisesDone;
using Engineer.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Service
{
    public class ExerciseDoneService
    {
        private readonly DataContext context;
        private IMapper Mapper { get; }
        public ExerciseDoneService(DataContext _context, IMapper mapper)
        {
            context = _context;
            Mapper = mapper;
        }

        #region Create()
        public async Task Create(FormModel model, long trainingId)
        {
            var exercise = Mapper.Map<ExerciseDone>(model);
            exercise.TrainingId = trainingId;

            await context.AddAsync<ExerciseDone>(exercise);
            await context.SaveChangesAsync();
        }

        public async Task Create(List<FormModel> model, long trainingId)
        {
            foreach(var exercise in model)
            {
                var entity = Mapper.Map<ExerciseDone>(exercise);
                entity.TrainingId = trainingId;

                await context.AddAsync<ExerciseDone>(entity);
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
