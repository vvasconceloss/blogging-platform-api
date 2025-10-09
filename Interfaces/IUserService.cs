using bloggin_plataform_api.DTOs.User;

namespace bloggin_plataform_api.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteAsync(int id);

        Task<UserResponseDTO> AddAsync(UserDTO user);

        Task<UserResponseDTO?> GetByIdAsync(int id);
        Task<IEnumerable<UserResponseDTO>> GetUsersAsync();
    }
}