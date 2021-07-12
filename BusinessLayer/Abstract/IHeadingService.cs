using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        void HeadingDelete(Heading heading);
        void Headingupdate(Heading heading);
        Heading GetByID(int id);
    }
}
