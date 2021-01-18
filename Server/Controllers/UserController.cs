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
    }
}
