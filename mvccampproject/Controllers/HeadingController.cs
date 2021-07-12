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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
       CatagoryManager cm = new CatagoryManager(new EfCatagoryDal());
        WriterManeger wm = new WriterManeger(new EfWriterDal());
        public ActionResult Index()
        {
            var value = hm.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                   Text = x.CatagoryName,
                                                   Value = x.CatagoryID.ToString()
                                                    }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem { 
                                                    Text =x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();

            ViewBag.vlc = valueCatagory;//bu hisse view da kategori secimlerin gelmesi ucundur
            ViewBag.wlc = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());//burani arasdir
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
       public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCatagory = (from x in cm.GetList()
                                                  select new SelectListItem {
                                                      Text = x.CatagoryName,
                                                      Value = x.CatagoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCatagory;
            var value = hm.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.Headingupdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var value = hm.GetByID(id);
            value.HeadingStatus = false;
            hm.HeadingDelete(value);
            return RedirectToAction("Index");
        }

    }
}