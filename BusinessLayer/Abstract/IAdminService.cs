using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void adminAdd(Admin admin);
        void adminDelete(Admin admin);
        void adminupdate(Admin admin);
        Writer GetByID(int id);
        Admin CheckAdmin(Admin p); 
    }
}
