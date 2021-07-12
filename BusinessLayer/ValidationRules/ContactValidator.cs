using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adini Bos girmissiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu hisse bos gecilmez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu hisse bos gecilmez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("ad 3 den az olammaz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("ad 3 den az olammaz!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("konu 50 den cox olammaz!");
        }
    }
}
