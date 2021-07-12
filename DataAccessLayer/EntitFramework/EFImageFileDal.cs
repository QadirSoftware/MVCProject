﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntitFramework
{
   public class EFImageFileDal: GenericRepository<ImageFiles>, IImageFileDal
    {
    }
}
