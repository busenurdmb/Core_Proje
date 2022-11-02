using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager mm = new WriterMessageManager(new EfWriterMessageDal());
      //alıcısı olduğumuz mesajlar
        public IActionResult RecevierMessageList()
        {
            TempData["DeleteUrl"] = "RecevierMessageList";
            string p;
            p = "Admin@gmail.com";
            var values = mm.GetListReceverMessage(p);
            return View(values);
        }
        //göndericisi olduğumuz mesajlar
        public IActionResult SenderMessageList()
        {
            TempData["DeleteUrl"] = "SenderMessageList";
            string p;
            p = "Admin@gmail.com";
            var values = mm.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
        //public IActionResult SenderMessageDetails(int id)
        //{
        //    var value = mm.TGetByID(id);
        //    return View(value);
        //}
        public IActionResult Delete(int id)
        {
            string ViewUrl = TempData["DeleteUrl"].ToString();
            var values = mm.TGetByID(id);
            mm.TDelete(values);
            return RedirectToAction(ViewUrl);
        }
        //public IActionResult RecevierDelete(int id)
        //{
        //    var values = mm.TGetByID(id);
        //    mm.TDelete(values);
        //    return RedirectToAction("RecevierMessageList");
        //}
        [HttpGet]
        public IActionResult AddMessageSend()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddMessageSend(WriterMessage p)
        {
            p.Sender = "Admin@gmail.com";
            p.SenderName = "Admin admin";
            p.Date = DateTime.Parse(DateTime.Now.ToString());
            Context c = new Context();
            var value = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = value;
            mm.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
