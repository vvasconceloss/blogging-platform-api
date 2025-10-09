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

        public async Task<UserResponseDTO> AddAsync(UserCreateDTO user)
        {
            var validator = new UserCreateValidator();
            var result = await validator.ValidateAsync(user);

            if (!result.IsValid)
                throw new ValidationException(result.ToDictionary());

            if (await _userRepository.GetByEmailAsync(user.EmailAddress) != null)
                throw new ValidationException(new Dictionary<string, string[]>{
                    { "EmailAddress", new []{"The email address has already been registered."} }
                });

            if (await _userRepository.GetByUsernameAsync(user.Username) != null)
                throw new ValidationException(new Dictionary<string, string[]>{
                    { "Username", new []{"The username '" + user.Username + "' has already been registered."} }
                });

            var newUser = new User
            {
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var userCreated = await _userRepository.AddAsync(newUser);

            return new UserResponseDTO
            {
                Id = userCreated.Id,
                Username = userCreated.Username,
                EmailAddress = userCreated.EmailAddress,
                CreatedAt = userCreated.CreatedAt,
                UpdatedAt = userCreated.UpdatedAt
            };
        }
        
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("The user with the Id '" + id + "' was not found");
            
            return new UserResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<ICollection<UserResponseDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersResponseDTO = users.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            }).ToList();

            return usersResponseDTO;
        }
    }
}