using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Dto.User;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.Include(p => p.Permissions).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Include(p => p.Permissions).ToListAsync();
        }

        public async Task<User?> UpdateUser(int id, UpdateUserRequestDto userDto)
        {
            User? existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
                return null;

            existingUser.Address = userDto.Address;
            existingUser.City = userDto.City;
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.State = userDto.State;
            existingUser.UserName = userDto.UserName;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}