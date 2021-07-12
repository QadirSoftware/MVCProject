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
    public class WriterManeger : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManeger(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetByID(int id)
        {
            return _writerdal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void writerAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public void Writerupdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
