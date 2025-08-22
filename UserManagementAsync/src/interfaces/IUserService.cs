using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementApi.Models;

namespace UserManagementApi.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User> AddUser(User newUser);
        Task<User?> UpdateUser(int id, User updatedUser);
        Task<bool> DeleteUser(int id);
    }
}
