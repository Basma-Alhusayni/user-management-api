using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Interfaces;
using UserManagementApi.Models;
using UserManagementApi.Dtos.User;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var result = _mapper.Map<List<UserDto>>(users);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDto newUserDto)
        {
            var user = _mapper.Map<User>(newUserDto);
            var createdUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, _mapper.Map<UserDto>(createdUser));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto updatedUserDto)
        {
            var updatedUser = _mapper.Map<User>(updatedUserDto);
            var result = await _userService.UpdateUser(id, updatedUser);
            if (result == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
