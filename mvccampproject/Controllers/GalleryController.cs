using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitFramework;

namespace mvccampproject.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imf = new ImageFileManager(new EFImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var image = imf.GetList();
            return View(image);
        }
    }
}