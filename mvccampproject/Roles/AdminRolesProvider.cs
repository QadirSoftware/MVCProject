using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitFramework;

namespace mvccampproject.Roles
{
    public class AdminRolesProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        AdminManager adm = new AdminManager(new EfAdminDal());

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            byte[] usernamehash;
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                usernamehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
                var user = adm.GetList();
                foreach (var item in user) 
                    {


                    for (int i = 0; i < usernamehash.Length; i++) {
                        if (usernamehash[i] == item.UserName[i]) {
                            return new string[] { item.AdminRole };
                        }
                    }
                  
                }
                return new string[] { };
            }
        }
           
            

           
          
        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}