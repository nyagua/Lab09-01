using Lab09_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample2022.Controllers
{
    public class PersonController : Controller
    {

        // GET: Person
        public ActionResult Index()
        {

            if (Session["people"] == null)
                Session["people"] = new List<PersonModel>();

            return View(Session["people"]);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {

            var model = ((List<PersonModel>)Session["people"]).Where(x => x.PersonID == id).FirstOrDefault();

            return View(model);
        }

        // GET: Person/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<PersonModel>)Session["people"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<PersonModel>)Session["people"]).Where(x => x.PersonID == id).FirstOrDefault();
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<PersonModel>)Session["person"]).Where(x => x.PersonID == id).FirstOrDefault();
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var list = ((List<PersonModel>)Session["person"]).ToList();
                var item = ((List<PersonModel>)Session["person"]).Single(r => r.PersonID == id);

                list.Remove(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
