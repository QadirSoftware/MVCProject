using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiveMail).NotEmpty().WithMessage("Alici Adini Bos girmissiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu Adini Bos girmissiniz!");
            RuleFor(x => x.MessegaContent).NotEmpty().WithMessage("Mesaji Bos girmissiniz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3karakter olmalidir");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En cox 100 karakter olmalidir");
        }
    }
}
