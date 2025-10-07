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
        public async Task<ActionResult<UserResponseDTO>> AddUser(UserDTO userDTO)
        {
            var user = await _userService.AddAsync(userDTO);
            return user;
        }
    }
}