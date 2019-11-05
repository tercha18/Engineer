using AutoMapper;
using Engineer.Models.Api.TrainingPlan;
using Engineer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Controllers
{
    [ApiController]
    [Route("api/training-plan")]
    public class TrainingPlanController : ControllerBase
    {
        private TrainingPlanService TrainingPlanService { get; set; }
        private IMapper Mapper { get; }

        public TrainingPlanController(TrainingPlanService training, IMapper mapper)
        {
            TrainingPlanService = training;
            Mapper = mapper;
        }

        #region Create()
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] FormModel model)
        {
            var result = await TrainingPlanService.Create(model);

            if(result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
