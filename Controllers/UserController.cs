using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitties.Models;
using Microsoft.AspNetCore.Mvc;
using Faker;

namespace Kitties.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly UserContext userContext;

        public UserController(UserContext context)
        {
            userContext = context;

            if (userContext.UserItems.Count() == 0)
            {
                userContext.UserItems.Add(new User {
                    Id = Guid.NewGuid().ToString(),
                    ApiKey = Guid.NewGuid().ToString(),
                    Username = "Admin",
                    Password = "Admin",
                });
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Create([FromBody] User userData)
        {
            if (userData.Username == null || userData.Password == null)
            {
                return BadRequest("Please fill in the required fields.");
            }

            User existingUser = userContext.UserItems.Where(
                u => u.Username == userData.Username).FirstOrDefault();
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            User createdUser = new User{
                Id = Guid.NewGuid().ToString(),
                ApiKey = Guid.NewGuid().ToString(),
                Username = userData.Username,
                Password = userData.Password
            };
            
            userContext.UserItems.Add(createdUser);
            userContext.SaveChanges();

            return new ObjectResult(createdUser);
        }

        //log in 
        //Kolla stavning
        [Route("login")]
        public IActionResult LogIn([FromBody] User userData)
        {
            if (userData.Username == null || userData.Password == null)
            {
                return BadRequest();
            }

            // userContext.UserItems.Where(u => u.ApiKey == userData.ApiKey);
            User foundUser = userContext.UserItems.Where(
                u => u.Username == userData.Username).FirstOrDefault();

            if (foundUser == null)
            {
                return BadRequest("User not found.");
            }

            if (foundUser.Equals(userData.Password) == false)
            {
                return BadRequest("Wrong Password");
            }

            //Create cookie token?

            return new ObjectResult(foundUser);
        }

    }
}