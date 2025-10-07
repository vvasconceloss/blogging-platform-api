using bloggin_plataform_api.DTOs.User;
using bloggin_plataform_api.Interfaces;

namespace bloggin_plataform_api.Services
{
    public class UserService(IUserRepository repo) : IUserService
    {
        private readonly IUserRepository _userRepository = repo;

        public Task<UserDTO> AddAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseDTO>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}