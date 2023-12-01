using MvcCv.Models.Entities;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        SkillsRepository skillsRepository = new SkillsRepository();
        public ActionResult Index()
        {
            var skills = skillsRepository.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult SkillsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillsAdd(TblSkills p)
        {

            skillsRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SkillsDelete(int id)
        {
            TblSkills t = skillsRepository.Find(x => x.ID == id);
            skillsRepository.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillsEdit(int id) {

            TblSkills t = skillsRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SkillsEdit(TblSkills s)
        {

            TblSkills t = skillsRepository.Find(x => x.ID == s.ID);
            t.Skill = s.Skill;
            t.Level = s.Level;
            skillsRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}