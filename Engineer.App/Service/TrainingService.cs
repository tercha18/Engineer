using AutoMapper;
using Engineer.Data;
using Engineer.Models.Api.Training;
using Engineer.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Service
{
    public class TrainingService
    {
        private readonly DataContext context;
        private IMapper Mapper { get; }
        private ExerciseDoneService ExerciseDoneService { get; set; }
        public TrainingService(DataContext _context, IMapper mapper, ExerciseDoneService exerciseDoneService)
        {
            context = _context;
            Mapper = mapper;
            ExerciseDoneService = exerciseDoneService;
        }

        #region Create()
        public async Task<Training> Create(FormModel model)
        {
            try
            {
                var training = Mapper.Map<Training>(model);
                training.ExecutionTime = DateTime.Now;
                training.UserId = await context.TrainingPlans
                                            .Where(p => p.Id == training.TrainingPlanId)
                                            .Select(p => p.UserId)
                                            .FirstOrDefaultAsync();

                await context.AddAsync<Training>(training);
                await context.SaveChangesAsync();

                if (model.ExercisesDone != null)
                    await ExerciseDoneService.Create(model.ExercisesDone, training.Id);

                return training;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region GetList()
        public async Task<List<ViewModel>> GetList(long userId)
        {
            try
            {
                var entities = await context.Trainings
                                    .Where(p => p.UserId == userId)
                                    .ToListAsync();

                return Mapper.Map<List<ViewModel>>(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Fetch()
        public async Task<ViewModel> Fetch(long trainingId)
        {
            try
            {
                var entity = await context.Trainings
                                    .Where(p => p.Id == trainingId)
                                    .Include(p=> p.ExercisesDone)
                                    .FirstOrDefaultAsync();

                return Mapper.Map<ViewModel>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update()
        public async Task<Training> Update(FormModel model, long trainingId)
        {
            try
            {
                var entity = await context.Trainings
                                    .Where(p => p.Id == trainingId)
                                    .Include(p=>p.ExercisesDone)
                                    .FirstOrDefaultAsync();

                var result = Mapper.Map<FormModel, Training>(model, entity);

                context.Update<Training>(result);
                await context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete()
        public async Task Delete(long trainingId)
        {
            try
            {
                var entity = await context.Trainings
                                    .Where(p => p.Id == trainingId)
                                    .Include(p => p.ExercisesDone)
                                    .FirstOrDefaultAsync();

                context.Remove<Training>(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
