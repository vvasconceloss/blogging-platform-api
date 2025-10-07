using Microsoft.AspNetCore.Mvc;
using bloggin_plataform_api.Interfaces;

namespace bloggin_plataform_api.Controllers
{
    [ApiController]
    public class UserController(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = repository;
    }
}