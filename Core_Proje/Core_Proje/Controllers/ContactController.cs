using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager( new EfMessageDal());
        public IActionResult Index()
        {
            var list = mm.TGetList();
            return View(list);
        }
        public IActionResult Delete(int id)
        {
            var values = mm.TGetByID(id);
            mm.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
    }
}
