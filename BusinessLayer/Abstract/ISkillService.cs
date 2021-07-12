using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface ISkillService
    {
        List<Skill> GetList();
        void SkillAddBL(Skill skill);
        Skill GetID(int id);
        void SkillDelete(Skill skill);
        void SkillUpdates(Skill skill);
    }
}
