using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        AboutManager am = new AboutManager(new EfAboutDal());

        public IViewComponentResult Invoke()
        {
            var list = am.TGetList();
            return View(list);
;        }
    }
}
