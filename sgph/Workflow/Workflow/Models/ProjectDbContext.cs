using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Workflow.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("workflowDb") 
        {
            Database.SetInitializer<ProjectDbContext>(new ProjectDbContextInitializer());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}