using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;

namespace mvccampproject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        public ActionResult GetContactDetails(int id)
        {
            var value = cm.GetID(id);
            return View(value);




        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult IsReading(int id)
        {
            var contactvalue = cm.GetID(id);
            if (contactvalue.IsReading == false)
            {
                contactvalue.IsReading = true;
            }
            else if(contactvalue.IsReading == true)
            {
                contactvalue.IsReading = false;
            }
            cm.ContactUpdate(contactvalue);
            return RedirectToAction("Index");
        }


    }
}