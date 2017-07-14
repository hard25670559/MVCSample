using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Empty.Models;
using System.Web.Mvc;

namespace Empty.Controllers
{
    public class HomeController : Controller
    {

        DB DB = new DB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult User()
        {
            List<User> l = new List<Models.User>();

            var selectData = from p in DB.User select p;

            return View(selectData);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(User model)
        {
            DB.User.Add(model);
            DB.SaveChanges();

            return RedirectToAction("User");
        }

        public ActionResult Edit(int id)
        {
            var selectData = from p in DB.User where p.Id == id select p;

            return View(selectData.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var selectData = from p in DB.User where p.Id == id select p;

            User u = selectData.FirstOrDefault();

            u.name = user.name;
            u.tel = user.tel;

            DB.SaveChanges();
            
            return RedirectToAction("User");
        }

        public ActionResult Delete(int id)
        {

            var selectData = from p in DB.User where p.Id == id select p;

            User u = selectData.FirstOrDefault();

            DB.User.Remove(u);

            DB.SaveChanges();

            return RedirectToAction("User");
        }

    }
}