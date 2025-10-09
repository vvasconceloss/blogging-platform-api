using Microsoft.AspNetCore.Mvc;
using bloggin_plataform_api.DTOs.User;
using bloggin_plataform_api.Interfaces;

namespace bloggin_plataform_api.Controllers
{
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _userService = service;

        [HttpPost]
        [Route("user/create")]
        public async Task<ActionResult> AddUser(UserCreateDTO createUser)
        {
            var user = await _userService.AddAsync(createUser);
            return Ok(user);
        }
        
        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
    }
}