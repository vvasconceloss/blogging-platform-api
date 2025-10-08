using bloggin_plataform_api.Data;
using bloggin_plataform_api.Models;
using bloggin_plataform_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bloggin_plataform_api.Repositories
{
    public class UserRepository(BlogDbContext context) : IUserRepository
    {
        private readonly BlogDbContext _context = context;

        public async Task<User> AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return user;
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

        public Task<User?> GetByEmailAsync(string email)
        {
            return _context.Users.Where(user => user.EmailAdress == email).FirstOrDefaultAsync();
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            return _context.Users.Where(user => user.Username == username).FirstOrDefaultAsync();
        }
    }
}