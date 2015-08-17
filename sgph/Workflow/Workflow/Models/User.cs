using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workflow.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userRole { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}