using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ProjectList : ViewComponent
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDal());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var list = pm.TGetList();
            return View(list);
        }
    }

}
