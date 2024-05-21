using EFCodeFirstApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;
        public UsersController(UserContext  usercontext)
        {
            this.userContext = usercontext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<Users>GetUsers()
        {
            return userContext.Users.ToList();
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            string response = string.Empty;
            userContext.Users.Add(user);
            userContext.SaveChanges();
            return "User Added";
        }

        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userContext.Users.Where(x=>x.Id== id).FirstOrDefault();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(Users user)
        {
            userContext.Entry(user).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges();
            return "User updated";

        }

        [HttpDelete]
        [Route("Deleteuser")]
        public string DeleteUser(int id)
        {
            Users user = userContext.Users.Where(x=>x.Id== id).FirstOrDefault();
            userContext.Remove(user);
            userContext.SaveChanges();
            return "User Deleted";
        }
    }
}
