using AutoMapper;
using Engineer.Models.Api.Training;
using Engineer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Engineer.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/training")]
    public class TrainingController : Controller
    {
        private TrainingService TrainingService { get; set; }
        private IMapper Mapper { get; set; }

        public TrainingController(TrainingService training, IMapper mapper)
        {
            TrainingService = training;
            Mapper = mapper;
        }

        #region Create()
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody]FormModel model)
        {
            var result = await TrainingService.Create(model);

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

        #region Fetch()
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ViewModel>> Fetch(long id)
        {
            var entity = await TrainingService.Fetch(id);

            if (entity == null)
                return NotFound();

            return entity;
        }
        #endregion

        #region Update()
        [HttpPost("{id}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create(long id, [FromBody]FormModel model)
        {
            var result = await TrainingService.Update(model, id);

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

        #region Delete()
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(long id)
        {
            await TrainingService.Delete(id);

            return Ok();
        }
        #endregion

        #region GetList()
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result =  await TrainingService.GetList(long.Parse(userId));

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
    }
}
