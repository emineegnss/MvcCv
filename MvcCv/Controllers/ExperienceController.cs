using MvcCv.Models.Entities;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var x = experienceRepository.List();

            return View(x);
        }
        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(TblExperience p) 
        { 

            experienceRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceDelete(int id)
        {
            TblExperience t = experienceRepository.Find(x => x.ID == id);
            experienceRepository.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperienceEdit(int id)
        {
            TblExperience t = experienceRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperienceEdit(TblExperience p)
        {
            TblExperience t = experienceRepository.Find(x => x.ID == p.ID);
            t.Subtitle=p.Subtitle;
            t.Title = p.Title;
            t.Description = p.Description;
            t.StartDate = p.StartDate;
            t.FinishDate = p.FinishDate;
            experienceRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}