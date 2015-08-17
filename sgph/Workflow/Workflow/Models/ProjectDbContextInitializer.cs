using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Workflow.Models
{
    public class ProjectDbContextInitializer : DropCreateDatabaseAlways<ProjectDbContext>
    {
        protected override void Seed(ProjectDbContext context)
        {
            new List<User>{
                new User(){userName="franklin", userEmail="franklinovic@gmail.com", userPhone="696197928", userRole="Guest", Id=1},
                new User(){userName="packa", userEmail="packa@gmail.com", userPhone="673310728", userRole="king", Id=2}

            }.ForEach(user => context.Users.Add(user));
            context.SaveChanges();

            new List<Client>{
                new Client(){clientAddress="douala", clientEmail="email@domain.com", clientName="Client test", clientPhone="237", Id=1},
                new Client(){clientAddress="ngola", clientEmail="email@domain.com", clientName="Client test", clientPhone="237", Id=2}
            }.ForEach(client => context.Clients.Add(client));
            context.SaveChanges();

            new List<Project>{
                new Project(){projectName="WorkFlow", projectOwner="Franklin", projectRefNum="5464654", projectResponsible="RAS", ClientId=1, UserId=1},
                new Project(){projectName="Workflow", projectOwner="billy", projectRefNum="54645264", projectResponsible="RAS", ClientId=1, UserId=2}
            }.ForEach(project => context.Projects.Add(project));
            context.SaveChanges();
        }
    }
}