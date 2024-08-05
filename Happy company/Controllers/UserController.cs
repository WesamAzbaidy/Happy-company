using AutoMapper;
using Happy_company.Data;
using Happy_company.Model.Domain;
using Happy_company.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Happy_company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(
            int pageNumber = 1,
            int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 5;

            var totalUsers = await _context.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);

            var users = await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(new { totalUsers, totalPages, pageNumber, pageSize, users = userDTOs });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest(new { message = "Email must be unique." });
            }

            var role = await _context.Roles.FindAsync(request.RoleId);
            if (role == null)
            {
                return BadRequest(new { message = "Role not found." });
            }

            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            user.Active = role.Type.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (_context.Users.Any(u => u.Email == request.Email && u.Id != id))
            {
                return BadRequest(new { message = "Email must be unique." });
            }

            _mapper.Map(request, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(user.RoleId);
            if (role != null && role.Type == "Admin")
            {
                return BadRequest(new { message = "Cannot delete an admin user." });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully." });
        }

        [HttpPut("{id}/change-active")]
        public async Task<IActionResult> ChangeUserActiveStatus(Guid id, [FromBody] ChangeActiveStatusRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Active = request.Active;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(new { message = "User active status updated successfully.", user = userDTO });
        }
    }
}
