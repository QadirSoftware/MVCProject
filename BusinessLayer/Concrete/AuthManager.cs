using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
      

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
            
        }

        public bool Login(LoginDto login)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {

                var user = _adminService.GetList();
                foreach (var item in user) {
                    if (HasingHelperFunction.HasingHelper.VeritfyPasswordHash(login.AdminPassword, login.AdminUserName, item.UserName, item.AdminPasswordHash, item.AdminPasswordSalt)) {
                        return true;
                    }
                }
                return false;
            }
                
            
        }

       
        public void Register(string adminUsername, string password)
        {
            byte[] usernamehash, passwordhashh, passwordsalt;
            HasingHelperFunction.HasingHelper.CreatPasswordHash(password, adminUsername,out usernamehash,out passwordhashh,out passwordsalt);
            Admin admin = new Admin() {
               UserName = usernamehash,
               AdminPasswordHash = passwordhashh,
            AdminPasswordSalt = passwordsalt,
            AdminRole = "B",
            };
            _adminService.adminAdd(admin);


        }

       
    }
}
