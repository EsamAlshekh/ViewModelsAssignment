using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelsAssignment.Models;
using PagedList;
using PagedList.Mvc;

namespace ViewModelsAssignment.Controllers
{
    public class HomeController : Controller
    {
        AssignmentsDBContext db = new AssignmentsDBContext();
        // GET: Home
        public ActionResult Index(PeopleViewModel vm)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(vm.sortBy) ? "Name dec" : "";
            ViewBag.SortCityParameter = string.IsNullOrEmpty(vm.sortBy) ? "City dec" : "City";


            //var People = from a in db.People.AsQueryable()/*.ToPagedList(page ?? 1, 3)*/
            //             select a;
            vm.People = db.People.ToList();
                         
            if (!string.IsNullOrEmpty(vm.searchString))
            {
                vm.People = db.People.Where(s => s.Name.Contains(vm.searchString) || s.City.Contains(vm.searchString)).ToList();
            }

            switch (vm.sortBy)
            {
                case "Name dec":
                    vm.People = vm.People.OrderByDescending(x => x.Name).ToList();
                    break;
                case "City dec":
                    vm.People = vm.People.OrderBy(x => x.City).ToList();
                    break;
                case "City":
                    vm.People = vm.People.OrderByDescending(x => x.City).ToList();
                    break;
                default:
                    vm.People = vm.People.OrderBy(x => x.Name).ToList();
                    break;

            }
            vm.pagedList = vm.People.ToPagedList(vm.page ?? 1, 3);
            return View(vm);
        }

        //// GET: Home/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(People person)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        //// GET: Home/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Home/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var Person = db.People.Find(id);
            return View(Person);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, People person)
        {
            try
            {
                // TODO: Add delete logic here
                var Person = db.People.Find(id);
                db.People.Remove(Person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(person);
            }
        }
    }
}
