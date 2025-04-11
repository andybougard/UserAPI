using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDBContext _context;
        public PermissionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            List<Permission> permissions = await _context.Permissions.ToListAsync();

            return permissions;
        }

        public async Task<Permission?> GetPermissionsById(int id)
        {
            Permission? permission = await _context.Permissions.FindAsync(id);

            return permission;
        }
        public async Task<List<Permission>> AddPermissionsAsync(List<Permission> permissions)
        {
            await _context.AddRangeAsync(permissions);
            await _context.SaveChangesAsync();

            return permissions;
        }

        public void removePermissions(List<Permission> permissions)
        {
            _context.Permissions.RemoveRange(permissions);
        }
    }
}