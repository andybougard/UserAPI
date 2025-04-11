using UserManagement.Dto.PermissionDtos;
using UserManagement.Models;

namespace UserManagement.Mappers
{
    public static class PermissionMapper
    {
        public static PermissionDto ToPermissionDto(this Permission permission)
        {
            PermissionDto permissionDto = new PermissionDto
            {
                Code = permission.Code,
                Description = permission.Description,
                UserId = permission.UserId
            };

            return permissionDto;
        }

        public static PermissionDto ToPermissionDto(this CreatePermissionRequestDto permission)
        {
            PermissionDto permissionDto = new PermissionDto
            {
                Code = permission.Code,
                Description = permission.Description,
                UserId = permission.UserId
            };

            return permissionDto;
        }

        public static Permission ToPermission(this PermissionDto permission)
        {
            Permission result = new Permission
            {
                Code = permission.Code,
                Description = permission.Description,
                UserId = permission.UserId
            };

            return result;
        }

        public static Permission ToPermission(this CreatePermissionRequestDto permission)
        {
            Permission result = new Permission
            {
                Code = permission.Code,
                Description = permission.Description,
                UserId = permission.UserId
            };

            return result;
        }
    }
}