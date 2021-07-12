using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Bu hisseni bos gecmiyin");
            RuleFor(x => x.SkillDetails).MinimumLength(5).WithMessage("En azi 5 karakter girin");
            RuleFor(x => x.SkillPoint).NotEmpty().WithMessage("Bu hisseni bos gecmiyin");
            RuleFor(x => x.SkillPoint).LessThan(101).WithMessage("100 den yuxari olmaz");
            RuleFor(x => x.SkillPoint).GreaterThan(0).WithMessage("0 dan asagi olmaz");



        }
    }
}
