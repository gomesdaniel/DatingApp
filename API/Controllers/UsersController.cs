
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
       private readonly DataContext _context;
       public UsersController(DataContext context)
       {
            _context = context;
       } 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsrs()
        {
           var users = await _context.Users.ToListAsync();
           return users;
         //   return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
           var user = await _context.Users.FindAsync(id);
           return user;
        }
    }
}