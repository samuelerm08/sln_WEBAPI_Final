using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Rivera.Data;
using SWProvincias_Rivera.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Rivera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : Controller
    {
        private readonly DbPaisContext context;
        public CiudadController(DbPaisContext context)
        {
            this.context = context;
        }

        //SELECT
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE            
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad c)
        {
            if (id != c.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE            
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from c in context.Ciudades
                          where c.IdCiudad == id
                          select c).SingleOrDefault();

            if (ciudad == null)
            {
                return NotFound();
            }

            context.Ciudades.Remove(ciudad);
            context.SaveChanges();

            return ciudad;
        }
    }
}
