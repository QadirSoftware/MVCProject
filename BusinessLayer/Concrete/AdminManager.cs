using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void adminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void adminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void adminupdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin CheckAdmin(Admin p)
        {
            throw new NotImplementedException();
        }

        public Admin CheckRole(byte[] username)
        {
            return _adminDal.Get(x => x.UserName == username);
        }




        public Writer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
