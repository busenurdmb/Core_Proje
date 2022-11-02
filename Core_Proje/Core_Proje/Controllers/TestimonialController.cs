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
    public class TestimonialController : Controller
    {
        TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var list = tm.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            tm.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult TestimonialDelete(int id)
        {
            var value = tm.TGetByID(id);
            tm.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {

            var dgr = tm.TGetByID(id);
            return View(dgr);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial p)
        {

            tm.Tupdate(p);
            return RedirectToAction("Index");
        }
    }
}
