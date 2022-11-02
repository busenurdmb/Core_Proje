using Core_Proje_Api.DAL.Api_Context;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            using var c = new Context();
            return Ok(c.categories.ToList());

        }
        [HttpGet("{id}")]
        public IActionResult GetidCategory(int id)
        {
            using var c = new Context();
            var values = c.categories.Find(id);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public IActionResult addcategory(Category category)
        {
            using var c = new Context();
           c.Add(category);
            c.SaveChanges();
            return Created("", category);
        }
        [HttpDelete]
        public IActionResult Deletecategory(int id)
        {
            using var c = new Context();
            var value = c.categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
            
        }
        [HttpPut]
        public IActionResult uptadeCategory(Category p)
        {
            using var c = new Context();
            var value = c.Find<Category>(p.CategoryID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategroyName = p.CategroyName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
