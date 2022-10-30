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
    public class MessageList : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            var VALUES = mm.TGetList().Take(5).ToList();
            return View(VALUES);
        }
    }
}
