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
    public class ContactSubplaceController : Controller
    {
        ContactManager fm = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {

            var values = fm.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {

            fm.Tupdate(p);
            return RedirectToAction("Index", "Default");
        }
    }
}
