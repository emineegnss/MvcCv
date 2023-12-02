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
            educationRepository.TAdd(e);
            return RedirectToAction("Index");
        }

    }
}