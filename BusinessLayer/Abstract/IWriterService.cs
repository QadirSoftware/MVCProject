using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IWriterService
    {
        List<Writer> GetList();
        void writerAdd(Writer writer);
        void WriterDelete(Writer writer);
        void Writerupdate(Writer writer);
        Writer GetByID(int id);
    }
}
