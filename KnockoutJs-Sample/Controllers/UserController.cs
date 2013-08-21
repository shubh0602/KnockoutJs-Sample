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
        public static SampleDataClassesDataContext dbctx = new SampleDataClassesDataContext();

        // GET api/user
        public IEnumerable<User> Get()
        {
            return dbctx.Users.ToList();

            //return MockGetUsers();
        }

        // GET api/user/5
        public User Get(int id)
        {
            return dbctx.Users.FirstOrDefault(x => x.Id == id);
            //return MockGetUsers().FirstOrDefault(x=>x.Id==id);
        }

        // POST api/user
        [HttpPost]
        public void Post(User value)
        {
            var user = dbctx.Users.FirstOrDefault(x => x.Id == value.Id);
            user.FirstName=value.FirstName;
            user.LastName=value.LastName;
            user.DOB=value.DOB;
            user.Others=value.Others;
            
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
        private IEnumerable<Models.User> MockGetUsers()
        {
            List<Models.User> users = new List<Models.User>();
            Models.User user1 = new Models.User()
            {
                Id = 1,
                FirstName = "Shubh",
                LastName = "Dasgupta",
                DOB = "06/02/1986",
                Others = "NA"
            };
            Models.User user2 = new Models.User()
            {
                Id = 2,
                FirstName = "Neeraj",
                LastName = "Mude",
                DOB = "06/02/1986",
                Others = "NA"
            };
            Models.User user3 = new Models.User()
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
