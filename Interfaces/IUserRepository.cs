using bloggin_plataform_api.Models;

namespace bloggin_plataform_api.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> DeleteAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);

        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}