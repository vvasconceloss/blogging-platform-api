using bloggin_plataform_api.Models;

namespace bloggin_plataform_api.Interfaces
{
    public interface IUserRepository
    {
        bool Add(User user);
        bool Delete(int id);
        User GetById(int id);
        User Update(User user);
        IEnumerable<User> GetAll();

        Task<bool> DeleteAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);

        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}