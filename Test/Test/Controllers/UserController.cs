using Microsoft.AspNetCore.Mvc;
using Test.Interfaces;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _allUsers;
        public UserController(IUser allUsers)
        {
            _allUsers = allUsers;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _allUsers.AllUsers;
            return users;
        }
        [HttpGet("{id}", Name = nameof(GetId))]
        public User? GetId(int id)
        {
            var user = _allUsers.getObjUser(id);
            return user;
        }

        [HttpPost]
        public string Post(User user)
        {
            _allUsers.AddUser(user);
            return "OK";
        }
    }
}

