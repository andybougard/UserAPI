using UserManagement.Dto.User;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(int id, UpdateUserRequestDto userDto);
    }
}