using bloggin_plataform_api.DTOs.User;

namespace bloggin_plataform_api.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> AddAsync(UserCreateDTO user);
        Task<UserResponseDTO?> GetByIdAsync(int id);
        Task<ICollection<UserResponseDTO>> GetUsersAsync();
        Task<string> DeleteAsync(int id);
    }
}