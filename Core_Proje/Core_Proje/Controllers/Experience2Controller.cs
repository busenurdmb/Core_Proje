using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager em = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            //listeleme işleminde SerializeObject
            //biz birşey gönderirken DeserializeObject
            var values = JsonConvert.SerializeObject(em.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            em.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExperienceID)
        {
            var v = em.TGetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);

        }
        public IActionResult DeleteExperience(int id)
        {
            var v = em.TGetByID(id);
            em.TDelete(v);
            return NoContent();

        }
        [HttpPost]
        public IActionResult updateExperience(int ExperienceID, string name ,string date)
        {
            var value = em.TGetByID(ExperienceID);
            if (value != null)
            {
                value.Name = name;
                value.Date = date;
                em.Tupdate(value);
                var values = JsonConvert.SerializeObject(value);
                return Json(values);
            }
            else
                return Json(new object());
        }
    }
}
