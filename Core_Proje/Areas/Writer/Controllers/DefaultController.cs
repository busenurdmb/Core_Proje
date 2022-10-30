using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager am = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var list = am.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            var value = am.TGetByID(id);
            return View(value);
        }

    }
}
