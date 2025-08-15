using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementApi.Models;

namespace UserManagementApi.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User newUser);
    }
}