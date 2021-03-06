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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;
        public ImageFileManager(IImageFileDal image)
        {
            _imageFileDal = image;
        }
        public List<ImageFiles> GetList()
        {
            return _imageFileDal.List();
        }
    }
}
