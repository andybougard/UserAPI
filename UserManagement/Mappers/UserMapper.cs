using UserManagement.Dto.User;
using UserManagement.Models;

namespace UserManagement.Mappers
{
    public static class UserMapper
    {
        public static UserDto toUserDto(this User user)
        {
            return new UserDto
            {
                id = user.Id,
                Address = user.Address,
                City = user.City,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Permissions = user.Permissions.Select(p => p.ToPermissionDto()).ToList(),
                State = user.State,
                UserName = user.UserName
            };
        }

        public static User ToUser(this CreateUserRequestDto userRequestDto)
        {
            return new User
            {
                Address = userRequestDto.Address,
                City = userRequestDto.City,
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                State = userRequestDto.State,
                UserName = userRequestDto.UserName
            };
        }
    }
}