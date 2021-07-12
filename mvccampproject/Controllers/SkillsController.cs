using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace mvccampproject.Controllers
{
    public class SkillsController : Controller
    { 
        SkillManager sm = new SkillManager(new EfSkillDal());
        // GET: Skills
        public ActionResult Index()
        {
            var value = sm.GetList();
            return View(value);
        }
        public ActionResult ListSkill()
        {
            var value = sm.GetList();
            return View(value);
        }
        public ActionResult Delete(int id)
        {
            var value = sm.GetID(id);
            sm.SkillDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkills(int id)
        {
            var value = sm.GetID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditSkills(Skill skill)
        {
            
            sm.SkillUpdates(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkills(Skill skill)
        {
            SkillValidator sv = new SkillValidator();
            ValidationResult result = sv.Validate(skill);
            if(result.IsValid)
                {
                sm.SkillAddBL(skill);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        }

    }
