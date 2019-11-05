using AutoMapper;
using Engineer.Models.Api.User;
using Engineer.Models.DataBase;
using Engineer.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engineer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService UserService { get; set; }
        private IMapper Mapper { get; }

        public UserController(UserService user, IMapper mapper)
        {
            UserService = user;
            Mapper = mapper;
        }

        #region Login()
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody]LoginModel model)
        {
            if (await UserService.UserExists(model.Username))
                return Ok();
            else
                return NotFound();
        }
        #endregion

        #region Register()
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]FormModel model)
        {
            model.Username = model.Username.ToLower();

            if (await UserService.UserExists(model.Username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje.");

            await UserService.Create(model, model.Password);

            return StatusCode(201);
        }
        #endregion

        #region Fetch()
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModel>> Fetch(long id)
        {
            var user = UserService.Fetch(id);

            if (user == null)
                return NotFound();

            return Mapper.Map<ViewModel>(user);
        }
        #endregion

        #region Update()
        [HttpPost("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody]FormModel model)
        {
            var user = UserService.Fetch(id);

            if (user == null)
                return NotFound();

            UserService.Update(model, user);

            return Ok();
        }
        #endregion
    }
}
