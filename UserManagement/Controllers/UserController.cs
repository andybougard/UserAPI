using Microsoft.AspNetCore.Mvc;
using UserManagement.Dto.User;
using UserManagement.Interfaces;
using UserManagement.Mappers;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("test")]
        public IActionResult TestApiConnection()
        {
            return Ok("Connection with api success");
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _userRepository.GetUsers();

            List<UserDto> result = users.Select(u => u.toUserDto()).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            User? result = await _userRepository.GetUser(id);

            if (result == null)
                return BadRequest("User not found");

            return Ok(result.toUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> createUser([FromBody] CreateUserRequestDto userRequest)
        {
            User newUser = await _userRepository.AddUser(userRequest.ToUser());

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser.toUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto updateUserRequest)
        {
            User? existingUser = await _userRepository.UpdateUser(id, updateUserRequest);

            if (existingUser == null)
                return BadRequest("User not found");

            return Ok(existingUser.toUserDto());
        }
    }
}