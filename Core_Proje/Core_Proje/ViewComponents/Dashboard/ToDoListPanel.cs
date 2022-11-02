using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        ToDoListManager tm = new ToDoListManager(new EfToDoListDal());
        
        public IViewComponentResult Invoke()
        {
            var list = tm.TGetList();
            return View(list);
        }
    }

}
