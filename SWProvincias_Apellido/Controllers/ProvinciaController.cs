using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Rivera.Data;
using SWProvincias_Rivera.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SWProvincias_Rivera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : Controller
    {
        private readonly DbPaisContext context;
        public ProvinciaController(DbPaisContext context)
        {
            this.context = context;
        }

        //SELECT
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE            
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia p)
        {
            if (id != p.ProvinciaId)
            {
                return BadRequest();
            }

            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE            
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var prov = (from p in context.Provincias
                        where p.ProvinciaId == id
                        select p).SingleOrDefault();

            if (prov == null)
            {
                return NotFound();
            }

            context.Provincias.Remove(prov);
            context.SaveChanges();

            return prov;
        }
    }
}
