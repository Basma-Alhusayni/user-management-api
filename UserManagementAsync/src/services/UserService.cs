using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Interfaces;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Profile).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Profile)
                                       .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddUser(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> UpdateUser(int id, User updatedUser)
        {
            var existingUser = await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null) return null;

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Address = updatedUser.Address;

            if (updatedUser.Profile != null)
            {
                if (existingUser.Profile == null)
                    existingUser.Profile = new Profile();

                existingUser.Profile.Bio = updatedUser.Profile.Bio;
                existingUser.Profile.PhoneNumber = updatedUser.Profile.PhoneNumber;
            }

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
