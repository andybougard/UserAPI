using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IPermissionRepository
    {
        public Task<List<Permission>> GetPermissionsAsync();
        public Task<Permission?> GetPermissionsById(int id);
        public Task<List<Permission>> AddPermissionsAsync(List<Permission> permissions);
        public void removePermissions(List<Permission> permissions);
    }
}