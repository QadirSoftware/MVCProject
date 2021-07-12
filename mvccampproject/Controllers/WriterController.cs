using BusinessLayer.Concrete;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace mvccampproject.Controllers
{
    public class WriterController : Controller
    {
        WriterManeger wm = new WriterManeger(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var WriterValue = wm.GetList();
            return View(WriterValue);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid) {
                wm.writerAdd(p);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writevalue = wm.GetByID(id);
            return View(writevalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid) {
                wm.Writerupdate(p);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}