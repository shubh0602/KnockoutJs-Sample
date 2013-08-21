using KnockoutJs_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockoutJs_Sample.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        public IEnumerable<User> Get()
        {
            return MockGetUsers();
        }

        // GET api/user/5
        public User Get(int id)
        {
            return MockGetUsers().FirstOrDefault(x=>x.Id==id);
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
        private IEnumerable<User> MockGetUsers() {
            List<User> users = new List<Models.User>();
            User user1 = new User()
            {
                Id = 1,
                FirstName = "Shubh",
                LastName = "Dasgupta",
                DOB = "06/02/1986",
                Others = "NA"
            };
            User user2 = new User()
            {
                Id = 2,
                FirstName = "Neeraj",
                LastName = "Mude",
                DOB = "06/02/1986",
                Others = "NA"
            };
            User user3 = new User()
            {
                Id = 3,
                FirstName = "Abhijit",
                LastName = "J",
                DOB = "06/02/1986",
                Others = "NA"
            };
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            return users;
        }
    }
}
