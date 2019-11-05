using AutoMapper;
using Engineer.Data;
using Engineer.Models.Api.TrainingPlan;
using Engineer.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Service
{
    public class TrainingPlanService
    {
        private DataContext context { get; set; }
        private IMapper Mapper { get; }

        public TrainingPlanService(DataContext _context, IMapper mapper)
        {
            context = _context;
            Mapper = mapper;
        }

        #region Create()
        public async Task<TrainingPlan> Create(FormModel model)
        {
            try
            {
                var entity = Mapper.Map<TrainingPlan>(model);

                //foreach(var exercise in model.exerciseId)

                await context.AddAsync<TrainingPlan>(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
