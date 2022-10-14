using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        public UsersController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async  Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.Users;
            return await users.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<AppUser> GetUser(int id)
        {
            try
            {
                var user = _context.Users.FindAsync(id);
                return await user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
