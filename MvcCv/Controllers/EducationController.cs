using MvcCv.Models.Entities;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository educationRepository = new EducationRepository();
        public ActionResult Index()
        {
            var education = educationRepository.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(TblEducation e)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            educationRepository.TAdd(e);
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int id)
        {
            TblEducation t = educationRepository.Find(x => x.ID == id);
            educationRepository.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationEdit(int id)
        {
            TblEducation t = educationRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EducationEdit(TblEducation p)
        {
            TblEducation t = educationRepository.Find(x => x.ID == p.ID);
            t.Institution = p.Institution;
            t.Faculty = p.Faculty;
            t.GPA = p.GPA;
            t.StartDate = p.StartDate;
            t.GraduationDate = p.GraduationDate;
            educationRepository.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}