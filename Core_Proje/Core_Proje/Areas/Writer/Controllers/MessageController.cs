using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    //[Area("Writer")]
    ////artık return RedirectToAction("SenderMessage","Message");
    ////message yazmmama gerek yok route takip etcek
    //[Route("Writer/Message")]
    [Area("Writer")]

   [ Route("Writer/{controller}/{action}/{id?}")]
    public class MessageController : Controller
    {
        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        //[Route("")]
        //[Route("RecevierMessage")]
        //alıcısı olduğumuz mesajlar
        public async Task< IActionResult> RecevierMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var list=wm.GetListReceverMessage(p);
            return View(list);
        }
        //[Route("")]
        //[Route("SenderMessage")]
        //gönderdiğimiz mesajlar
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var list = wm.GetListSenderMessage(p);
            return View(list);
        }
        //[Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            var value = wm.TGetByID(id);
            return View(value);
        }
        //[Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            var value = wm.TGetByID(id);
            return View(value);
        }
        [HttpGet]
        //[Route("")]
        //[Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        //[Route("")]
        //[Route("SendMessage")]
        public async Task< IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x =>x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            wm.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
