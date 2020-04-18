using System;
using Microsoft.AspNetCore.Mvc;
using CeloInterview_RestAPi_Test.Models;
using CeloInterview_RestAPi_Test.Repositories;

namespace CeloInterview_RestAPi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repositoryContext;            

        public UsersController(UsersContext context)
        {
            _repositoryContext = new UserRepository(context);
        }

        // GET: api/Users
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
                return BadRequest("User Belonging to the mentioned Id cannot be found");
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUserDetailsBasedOnId(int id,[FromBody] Users user)
        {
            bool updateStatus = _repositoryContext.UpdateUserBasedOnId(id, user);
            if (updateStatus)
                return Ok(_repositoryContext.GetUsersBasedOnId(id));
            else
                return BadRequest("User belonging to the mentioned Id not found");

        }
        //POST: api/Users
        [HttpPost]
        public IActionResult CreateNewUser([FromBody] Users user)
        {
            bool updateStatus = _repositoryContext.InsertNewUser(user);
            if (updateStatus)
                return Ok("Successfully Inserted");
            else
                return BadRequest("Please Provide Proper User Details in this order Title, FirstName, LastName, EmailId, PhoneNumber, DateOfBirth[DD-MON-YY], ProfileImages(optional)");

        }



    }
}
