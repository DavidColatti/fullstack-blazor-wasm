using System;
using Microsoft.AspNetCore.Mvc;
using fullstackblazorwasm.Server.Controllers;
using fullstackblazorwasm.Server.Models;
using System.Collections.Generic;
using fullstackblazorwasm.Shared;
using System.Linq;

namespace fullstackblazorwasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET api/user
        [HttpGet("")]
        public ActionResult<List<User>> GetUsers()
        {
            return _userContext.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            return _userContext.Users.FirstOrDefault(user => user.Id == id);
        }

        // POST api/user
        [HttpPost("")]
        public ActionResult<User> PostUser(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return user;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<User> PutUser(int id, User user)
        {
            User newUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.Password = user.Password;
            _userContext.SaveChanges();
            return newUser;
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void DeleteUserById(int id)
        {
            User oldUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
            _userContext.Users.Remove(oldUser);
        }
    }
}
