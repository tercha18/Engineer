using AutoMapper;
using Engineer.Data;
using Engineer.Models.Api.Exercise;
using Engineer.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Service
{
    public class ExerciseService
    {
        private readonly DataContext context;
        private IMapper Mapper { get; }
        public ExerciseService(DataContext _context, IMapper mapper)
        {
            context = _context;
            Mapper = mapper;
        }

        #region Create()
        public async Task<Exercise> Create(FormModel model)
        {
            var entity = Mapper.Map<Exercise>(model);

            await context.AddAsync<Exercise>(entity);
            await context.SaveChangesAsync();

            return entity;
        }
        #endregion
    }
}
