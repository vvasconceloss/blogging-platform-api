using Microsoft.AspNetCore.Mvc;
using bloggin_plataform_api.Interfaces;

namespace bloggin_plataform_api.Controllers
{
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _userService= service;
    }
}