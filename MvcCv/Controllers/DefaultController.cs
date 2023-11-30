using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entities;
namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var items = db.TblAbout.ToList();
            return View(items);
        }
        public PartialViewResult Experience()
        {
            var experience = db.TblExperience.ToList();
            return PartialView(experience);
        }
        public PartialViewResult Education()
        {
            var education = db.TblEducation.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skills()
        {
            var skill = db.TblSkills.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Interests()
        {
            var interests = db.TblInterests.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificate()
        {
            var certificate = db.TblCertificate.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString()) ;
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}