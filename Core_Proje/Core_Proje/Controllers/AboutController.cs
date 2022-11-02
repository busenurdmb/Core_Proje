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
    public class AboutController : Controller
    {
        AboutManager fm = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            
            var values = fm.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About p)
        {

            fm.Tupdate(p);
            return RedirectToAction("Index", "Default");
        }
    }
}
