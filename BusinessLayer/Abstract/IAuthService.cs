using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayer.Dto;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        bool Login(LoginDto loginDto);
    
    }
}