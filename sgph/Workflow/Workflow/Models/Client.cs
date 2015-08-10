using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workflow.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string clientName { get; set;}
        public string clientPhone{get; set;}
        public string clientEmail { get; set; }
        public string clientAddress { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}