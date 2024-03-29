﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class WorkflowRepository : IRepository
    {
        private ProjectDbContext context = new ProjectDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public Task<int> saveUser(User user)
        {
            if (user.Id == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User leUser = context.Users.Find(user.Id);
                if (leUser != null)
                {
                    leUser.userEmail = user.userEmail;
                    leUser.userName = user.userName;
                    leUser.userPhone = user.userPhone;
                    leUser.userRole = user.userRole;
                }
            }
            return context.SaveChangesAsync();
        }
        public User deleteUser(int userId)
        {
            User leUser = context.Users.Find(userId);
            if (leUser != null)
            {
                context.Users.Remove(leUser);
            }
            context.SaveChangesAsync();

            return leUser;
        }

        public IEnumerable<Project> Projects
        {
            get
            {
                IEnumerable<Project> projets = context.Projects;

                foreach (var p in projets)
                {
                    p.User = context.Users.Find(p.UserId);
                    p.Client = context.Clients.Find(p.ClientId);
                }
                return projets;
            }
        }

        //public Task<int> saveProject(Project project)
        //{
        //    if (project.Id == 0)
        //    {
        //        context.Projects.Add(project);
        //    }
        //    else
        //    {
        //        Project leprojet = context.Projects.Find(project.Id);
        //        if (leprojet != null)
        //        {
        //            leprojet.projectName = project.projectName;
        //            leprojet.projectOwner = project.projectOwner;
        //            leprojet.projectRefNum = project.projectRefNum;
        //            leprojet.projectResponsible = project.projectResponsible;
        //        }
        //    }
        //    return context.SaveChangesAsync();
        //}

        //alternative function from Dorgeles because previous produce a bug
        public int saveProject(Project project)
        {
            if (project.Id == 0)
            {
                context.Projects.Add(project);
            }
            else
            {
                Project leProject = context.Projects.Find(project.Id);
                if (leProject != null)
                {
                    leProject.projectName = project.projectName;
                    leProject.projectOwner = project.projectOwner;
                    leProject.projectRefNum = project.projectRefNum;
                    leProject.projectResponsible = project.projectResponsible;
                }
            }
            return context.SaveChanges();
        }

        //public Project deleteProject(int projectId)
        //{
        //    Project p = context.Projects.Find(projectId);
        //    if (p != null)
        //    {
        //        context.Projects.Remove(p);
        //    }
        //    context.SaveChangesAsync();

        //    return p;
        //}

        //alternative function from Dorgeles because previous produce a bug
        public Project deleteProject(int ProjectId)
        {
            Project leProject = context.Projects.Find(ProjectId);
            if (leProject != null)
            {
                context.Projects.Remove(leProject);
                context.SaveChanges();
            }
            return leProject;
        }

        public Project findProject(int projectID)
        {
            Project project = context.Projects.Find(projectID);
            if (project != null)
            {
                project.Client = context.Clients.Find(project.ClientId);
                project.User = context.Users.Find(project.UserId);
            }
            return project;
        }

        public IEnumerable<Client> Clients {
            get { return context.Clients; }
        }
        public Task<int> saveClient(Client client)
        {
            if (client.Id == 0)
            {
                context.Clients.Add(client);
            }
            else
            {
                Client c = context.Clients.Find(client.Id);
                if (c != null)
                {
                    c.clientEmail = client.clientEmail;
                    c.clientAddress = client.clientAddress;
                    c.clientName = client.clientName;
                    c.clientPhone = client.clientPhone;
                }
            }
            return context.SaveChangesAsync();
        }
        public Client deleteClient(int clientId)
        {
            Client c = context.Clients.Find(clientId);
            if (c != null)
            {
                context.Clients.Remove(c);
            }

            return c;
        }

    }
}