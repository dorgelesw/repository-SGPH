using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workflow.Models;

namespace Workflow.Controllers
{
    public class UsersController : ApiController
    {
        private IRepository repository{get; set;}
        public UsersController()
        {
            repository = new WorkflowRepository();
        }

        //Get:/api/Users
        public IEnumerable<User> GetUsers()
        {
            return repository.Users;
        }
        //GET: /api/Users/5

        public User GetUsers(int id)
        {
            User us = repository.Users.Where(r => r.Id == id).FirstOrDefault();
            return us;
            
        }

        //POST: /api/Users
        [HttpPost]
        public User PostUsers(User users)
        {
            repository.saveUser(users);
            return users;
        }

        public User DeleteUsers(int id)
        {
            return repository.deleteUser(id);
        }
        public User Edit(int id)
        {
            User us = repository.Users.FirstOrDefault(r => r.Id == id);

            return us;
        }


    }
}
