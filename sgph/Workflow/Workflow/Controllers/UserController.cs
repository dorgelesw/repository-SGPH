using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
namespace Workflow.Controllers
{
    public class UserController : Controller
    {
        private ProjectDbContext context = new ProjectDbContext();
        private IRepository repository;
        // GET: User
        public UserController()
        {
            repository = new WorkflowRepository();
        }
        public ActionResult Index()
        {
            ViewBag.users = repository.Users;
            return View("Index");
        }

        public ActionResult Create()
        {

            return View();
        }

        //POST: /Home/create
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]

        public ActionResult Create(User users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Users.Add(users);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

            }
            return View(users);
        }
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User us = context.Users.Find(Id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);


        }
        //GET: /Users/Edit
        public ActionResult Edit(int id=0)
        {
            User us = context.Users.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);

        }
        //POST:/Users/Edit/5
    [HttpPost]
        public ActionResult Edit(User users)
        {
            if (ModelState.IsValid)
            {
                context.Entry(users).State = EntityState.Modified;
                context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(users);
        }
        //GET: /Users/Delete

    public ActionResult Delete(int? id, bool? savesChangeError=false)
    {
        
        if (id == null)
        {
            return HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        if (savesChangeError.GetValueOrDefault())
        {
            ViewBag.Errormessage = "Delete Fail. try again, and if the problem persist contact the system administrator.";
        }
        User us = context.Users.Find(id);
        if (us == null)
        {
            return HttpNotFound();
        }
        return View(us);
    }
        [HttpPost]
    [ValidateAntiForgeryToken] //represente un attribut qui permet de lutter contre la contrefacons d'une requette
    
            /*This code retrieves the selected entity, then calls the Remove method to set the entity's status to Deleted*/
    public ActionResult Delete(int id)
    {
            //manage any error appear when the database is updated
        try
        {
            User us = context.Users.Find(id);
            context.Users.Remove(us);
            context.SaveChangesAsync();
        }
        catch (System.Data.DataException)
        {
            //log the error
            return RedirectToAction("Dalete", new {id=id,savechangeError=true});
        }
            return RedirectToAction("Index");
    }

    private ActionResult HttpStatusCodeResult(HttpStatusCode httpStatusCode)
    {
        throw new NotImplementedException();
    }
        
    }
}