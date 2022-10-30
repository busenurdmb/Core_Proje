using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var list = sm.TGetList();
            return View(list);
        }
    }
}
