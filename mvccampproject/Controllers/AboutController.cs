using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;

namespace mvccampproject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var value = am.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            am.AboutAddBL(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial() 
        {
            return PartialView();
        }
        public ActionResult ChangeTrue(int id)
        {
            var value = am.GetID(id);
            if(value.AboutStatus == false) {
                value.AboutStatus = true;
            }
            am.AboutUpdate(value);
           return RedirectToAction("Index");

        }
        public ActionResult ChangeFalse(int id)
        {
            var value = am.GetID(id);
            if (value.AboutStatus == true) {
                value.AboutStatus = false;
            }
            am.AboutUpdate(value);

            return RedirectToAction("Index");
        }


    }
}