using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Models;

namespace Workflow.Controllers
{
  
    public class ClientsController : ApiController
    {
        private IRepository repository;

        public ClientsController()
        {
            repository = new WorkflowRepository();
        }
    [HttpDelete]
        public Client Delete(int id){

            Console.WriteLine("id=" + id);

            return repository.deleteClient(id);
        }

    public IEnumerable<Client> GetClients()
    {
        return repository.Clients;
    }
    public Client GetClients(int id)
    {
        Client us = repository.Clients.Where(r => r.Id == id).FirstOrDefault();
        return us;
    }
    [HttpPost]
    public Client PostClient(Client client)
    {
        repository.saveClient(client);
        return client;
    }
        
     public Client Edit(int id)
        {
            Client us = repository.Clients.FirstOrDefault(r => r.Id == id);
          
            return us;

        }


    }
}
