using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            
            var list = sm.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill p)
        {
            sm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var dgr=sm.TGetByID(id);
            sm.TDelete(dgr);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
           
            var dgr = sm.TGetByID(id);
            return View(dgr);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill p)
        {
            
            sm.Tupdate(p);
            return RedirectToAction("Index");
        }
    }
}
