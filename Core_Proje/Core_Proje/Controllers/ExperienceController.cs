using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    [Authorize(Roles ="Admin")]
    
    public class ExperienceController : Controller
    {
        ExperienceManager em = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            
            var list = em.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            em.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            var dgr = em.TGetByID(id);
            em.TDelete(dgr);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            
            var dgr = em.TGetByID(id);
            return View(dgr);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience p)
        {

            em.Tupdate(p);
            return RedirectToAction("Index");
        }
    }
}
