using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workflow.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string projectRefNum { get; set; }
        public string projectName { get; set; }
        public string projectOwner { get; set; }
        public string projectResponsible { get; set; }

        public int ClientId { get; set; }
        public int UserId { get; set; }

        public Client Client { get; set; }
        public User User { get; set; }
    }
}