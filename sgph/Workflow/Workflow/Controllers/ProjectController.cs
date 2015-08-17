using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow.Models;

namespace Workflow.Controllers
{
    public class ProjectController : Controller
    {
        private IRepository repository;
        //private ProjectDbContext context = new ProjectDbContext();

        public ProjectController()
        {
            repository = new WorkflowRepository();
        }

        //public ActionResult Details(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    Project us = context.Projects.Find(Id);
        //    if (us == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(us);
        //}

        // GET: /Project/
        public ActionResult Index()
        {
            ViewBag.statut = "";
            return View(repository.Projects);
        }

        //GEt:/project/
          [HttpGet]
        public ActionResult Create()
        {
            ViewBag.clients = repository.Clients;
            ViewBag.users = repository.Users;
            return View();

        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.saveProject(project);
                    ViewBag.statut = "Project " + project.projectName + " created";
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {
              
            }
            return View("Index", repository.Projects);

        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Project project = repository.findProject(id);
            if (project == null)
            {
                return HttpNotFound("Project Not Found");
            }
            return View(project);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Project project = repository.findProject(id);
            if (project == null)
            {
                return HttpNotFound("Project Not Found");
            }
            ViewBag.clients = repository.Clients;
            ViewBag.users = repository.Users;
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            repository.saveProject(project);
            ViewBag.statut = "Project " + project.projectName + " updated";
            return View("Index", repository.Projects);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Project project = repository.deleteProject(id);
            if (project == null)
            {
                return HttpNotFound("Project Not Found");
            }
            ViewBag.statut = "Project " + project.projectName + " deleted";
            return View("Index", repository.Projects);
        }
   
    }
}