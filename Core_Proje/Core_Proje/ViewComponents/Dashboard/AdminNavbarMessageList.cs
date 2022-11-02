using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            
           string p = "Admin@gmail.com";
           var list = (from x in context.Users
                       join y in context.WriterMessages
                       on x.Email equals y.Sender
                       where y.Receiver == p 
                       select new WriterMessageImageUrl
                       {
                           ImageUrl = x.ImageUrl,
                           Date = y.Date,
                           SenderName = y.SenderName,
                           MessageContent = y.MessageContent,
                           Id = y.WriterMessageID
                       }).OrderByDescending(x => x.Id).Take(3).ToList();
            return View(list);
        }

    }
}
