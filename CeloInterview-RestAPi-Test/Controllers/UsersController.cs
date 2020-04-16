using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CeloInterview_RestAPi_Test.Models;
using CeloInterview_RestAPi_Test.Repositories;

namespace CeloInterview_RestAPi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UsersContext _context;
        private readonly IUserRepository _repositoryContext;

        /* public UsersController(UsersContext context)
         {
             _context = context;
         }*/

        public UsersController(UsersContext context)
        {
            _repositoryContext = new UserRepository(context);
        }

        // GET: api/Users
        /*public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }*/
        [HttpGet]

        public IActionResult GetUsers()
        {
            return Ok(_repositoryContext.GetAllUsers());    
        }

        //GET: api/Users/3 
        [HttpGet("{quantity:int}")]
        public IActionResult FetchRandomUsersBasedOnQuantity(int quantity)
        {
            return Ok(_repositoryContext.FetchUsersBasedOnQuantitySpecified(quantity));
        }

        //Get: api/Users/Santosh
        [HttpGet("{name}")]
        public IActionResult FetchUsersBasedOnName(string name)
        {
            return Ok(_repositoryContext.GetUsersBasedOnName(name));
        }

        //GET: api/Users/id/1 
        [HttpGet("id/{id:int}")]
        public IActionResult FetchUserBasedOnUserId(int id)
        {
            return Ok(_repositoryContext.GetUsersBasedOnId(id));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserBasedOnId(int id)
        {
            bool deleteStatus = _repositoryContext.DeleteUserBasedOnUserId(id);
            if (deleteStatus)
                return Ok(_repositoryContext.GetAllUsers());
            else
                throw new Exception("User belonging to the mentioned Id not found");
        }

        /*
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        */
    }
}
