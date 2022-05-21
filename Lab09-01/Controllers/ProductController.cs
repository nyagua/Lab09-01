using Lab09_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab09_01.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            if (Session["product"] == null)
                Session["product"] = new List<ProductModel>();

            return View(Session["product"]);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var model = ((List<ProductModel>)Session["product"]).Where(x => x.ProductID == id).FirstOrDefault();  
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<ProductModel>)Session["product"]).Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<ProductModel>)Session["product"]).Where(x => x.ProductID == id).FirstOrDefault();
            return View(model);
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<ProductModel>)Session["product"]).Where(x => x.ProductID == id).FirstOrDefault();
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var list = ((List<ProductModel>)Session["product"]).ToList();
                var item = ((List<ProductModel>)Session["product"]).Single(r => r.ProductID == id);

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
