using System.Net.Mail;
using bloggin_plataform_api.Models;
using bloggin_plataform_api.DTOs.User;
using bloggin_plataform_api.Interfaces;
using bloggin_plataform_api.Exceptions;
using bloggin_plataform_api.Validators;

namespace bloggin_plataform_api.Services
{
    public class UserService(IUserRepository _repo) : IUserService
    {
        private readonly IUserRepository _userRepository = _repo;

        public async Task<UserResponseDTO> AddAsync(UserDTO user)
        {
            var validator = new UserValidator();
            var result = await validator.ValidateAsync(user);

            if (!result.IsValid)
                throw new ValidationException(result.ToDictionary());

            var newUser = new User
            {
                Username = user.Username,
                EmailAdress = user.EmailAddress,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var userCreated = await _userRepository.AddAsync(newUser);

            return new UserResponseDTO
            {
                Username = userCreated.Username,
                EmailAdress = userCreated.EmailAdress,
            };
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

        public Task<UserResponseDTO> UpdateAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}