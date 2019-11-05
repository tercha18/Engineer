using AutoMapper;
using Engineer.Models.Api.Exercise;
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
    [Route("api/exercise")]
    public class ExerciseController : Controller
    {
        private ExerciseService ExerciseService { get; set; }
        private IMapper Mapper { get; set; }

        public ExerciseController(ExerciseService exerciseService, IMapper mapper)
        {
            ExerciseService = exerciseService;
            Mapper = mapper;
        }

        #region Create()
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody]FormModel model)
        {
            var result = await ExerciseService.Create(model);

            if (result != null)
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
