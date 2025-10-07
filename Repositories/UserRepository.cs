using bloggin_plataform_api.Models;
using Microsoft.EntityFrameworkCore;
using bloggin_plataform_api.Interfaces;

namespace bloggin_plataform_api.Repositories
{
    public class UserRepository(DbContext context) : IUserRepository
    {
        private readonly DbContext _context = context;

        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}