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
        private ProjectDbContext context = new ProjectDbContext();

        public ProjectController()
        {
            repository = new WorkflowRepository();
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project us = context.Projects.Find(Id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);


        }
        // GET: /Project/
        public ActionResult Index()
        {
            return View(repository.Projects);
        }

        //GEt:/project/
        public ActionResult Create()
        {
            ViewBag.clients = repository.Clients;
            ViewBag.users = repository.Users;
            return View();

        }

        //Post:/Home/project
    [HttpPost]
        public ActionResult Create(Project projects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Projects.Add(projects);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {
              
            }
            return View(projects);

        }


   
    }
}