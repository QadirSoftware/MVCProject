using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitFramework;
using EntityLayer.Dto;

namespace mvccampproject.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService atm = new AuthManager(new AdminManager(new EfAdminDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto p)
        {
            atm.Register(p.AdminUserName, p.AdminPassword);

            return RedirectToAction(nameof(LoginController.Index));
        }
    }
}