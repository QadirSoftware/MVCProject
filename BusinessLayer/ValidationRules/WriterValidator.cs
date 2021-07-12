using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adini Bos girmissiniz!");
            RuleFor(x => x.WriterPassWord).NotEmpty().WithMessage("Bu hisse bos gecilmez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("bos gecilmez");
            RuleFor(x => x.WriterTittle).NotEmpty().WithMessage("bos gecilmez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("ad 2 den az olammaz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Soyaad 50 den cox olammaz!");
        }
    }
}
