using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager sm = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var list = sm.TGetList();
            return View(list);
        }
    }
}
