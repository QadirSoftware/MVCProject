using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace mvccampproject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager( new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        // GET: Message
        [Authorize]
        public ActionResult InBox()
        {
            var value = mm.GetListInbox();
            return View(value);
        }
        public ActionResult SendBox()
        {
            int i = 0;
            var value = mm.GetListSendbox();
            foreach(var j in value)
            {
                i++;
            }
            ViewBag.d1 = i;
            return View(value);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var value = mm.GetID(id);
          
           
            
            return View(value);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var value = mm.GetID(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid) {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(p);
                return RedirectToAction("InBox");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult IsReading(int id)
        {
            var messagevalue = mm.GetID(id);
            if(messagevalue.IsReading == true)
            {
                messagevalue.IsReading = false;
            }
            else 
            {
                messagevalue.IsReading = true;
            }
           
          mm.MessageUpdate(messagevalue);
          return  RedirectToAction("InBox");

        }
    }
}