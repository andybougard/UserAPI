using Microsoft.AspNetCore.Mvc;
using UserManagement.Dto.PermissionDtos;
using UserManagement.Interfaces;
using UserManagement.Mappers;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/permission")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            List<Permission> result = await _permissionRepository.GetPermissionsAsync();

            return Ok(result.Select(p => p.ToPermissionDto()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById([FromRoute] int id)
        {
            Permission? permission = await _permissionRepository.GetPermissionsById(id);
            if (permission == null)
                return BadRequest("Permission not found");
            return Ok(permission.ToPermissionDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddPermissions([FromBody] List<CreatePermissionRequestDto> permissions)
        {
            await _permissionRepository.AddPermissionsAsync(permissions.Select(p => p.ToPermission()).ToList());

            return Ok(permissions.Select(p => p.ToPermissionDto()));
        }
    }
}