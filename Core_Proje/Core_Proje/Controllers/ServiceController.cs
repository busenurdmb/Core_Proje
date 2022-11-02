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
    public class ServiceController : Controller
    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
          
            var list = sm.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddService()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service p)
        {
            sm.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var dgr = sm.TGetByID(id);
            sm.TDelete(dgr);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
          
            var dgr = sm.TGetByID(id);
            return View(dgr);
        }
        [HttpPost]
        public IActionResult EditService(Service p)
        {

            sm.Tupdate(p);
            return RedirectToAction("Index");
        }
    }
}

