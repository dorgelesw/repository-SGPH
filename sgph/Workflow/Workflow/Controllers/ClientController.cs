using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workflow.Models;

namespace Workflow.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        private ProjectDbContext context = new ProjectDbContext();
        
        private IRepository repository;
        public ClientController()
        {
           repository = new WorkflowRepository(); 
        }
        public ActionResult Index()
        {
            ViewBag.clients = repository.Clients;
            return View("IndexApi");
        }
        //GET:client

        public ActionResult Create()
        {

            return View();
        }

        //POST: /Home/create
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]

        public ActionResult Create(Client clients)
        {
            try
                 {
                 if (ModelState.IsValid)
                 {
                     context.Clients.Add(clients);
                     context.SaveChanges();
                     return RedirectToAction("Index");
                 }
                 }
                 catch (DataException)
                 {
    
                 }
                 return View(clients);
        }
        
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client us = context.Clients.Find(Id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);


        }
        //GET: /Users/Edit
        public ActionResult Edit(int id)
        {
            Client us = context.Clients.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);

        }
        //POST:/Users/Edit/5
    [HttpPost]
        public ActionResult Edit(Client clients)
        {
            if (ModelState.IsValid)
            {
                context.Entry(clients).State = EntityState.Modified;
                context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(clients);
        }
        //GET: /Users/Delete

    public ActionResult Delete(int id, bool savesChangeError=false)
    {
        
        if (id == null)
        {
            return HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        if (savesChangeError)
        {
            ViewBag.Errormessage = "Delete Fail. try again, and if the problem persist contact the system administrator.";
        }
         Client us = context.Clients.Find(id);
        if (us == null)
        {
            return HttpNotFound();
        }
        return View(us);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
            //manage any error appear when the database is updated
        try
        {
            Client us = context.Clients.Find(id);
            //recupere la liste des project qui sont associees a un client
           IEnumerable<Project> list =context.Projects.Where(Project => Project.ClientId == id);
           if (list == null) {
               context.Clients.Remove(us);
               context.SaveChangesAsync();

           }
        }
        catch (System.Data.DataException)
        {
            //log the error
            return RedirectToAction("Delete", new {id=id,savechangeError=true});
        }
            return RedirectToAction("Index");
    }

    private ActionResult HttpStatusCodeResult(HttpStatusCode httpStatusCode)
    {
        throw new NotImplementedException();
    }
        
    }
}
    
