using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager em = new PortfolioManager(new EfPortfolioDal());
        PortfolioValidator validations = new PortfolioValidator();
       
        public IActionResult Index()
        {
            
            var list = em.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {
           
            
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                em.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeletePortfolio(int id)
        {
            var dgr = em.TGetByID(id);
            em.TDelete(dgr);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
          
            var dgr = em.TGetByID(id);
            return View(dgr);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio p)
        {
            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                em.Tupdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
 
        }
    }
}
