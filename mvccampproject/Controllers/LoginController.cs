using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace mvccampproject.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        IAuthService atm = new AuthManager(new AdminManager(new EfAdminDal()));

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            //Context c = new Context();
            //var adminuser = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);

          
            //var adminuserinfo = am.CheckAdmin(p);
            if (atm.Login(loginDto)) 
                {
                
                FormsAuthentication.SetAuthCookie(loginDto.AdminUserName, false);
                Session["AdminUsername"] = loginDto.AdminUserName;
                return RedirectToAction("Index", "AdminCatagory");
            }
            else {
                return RedirectToAction("Index");
            }
        }
        }
}