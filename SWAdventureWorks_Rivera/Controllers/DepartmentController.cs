using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Rivera.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Rivera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        //INYECCION DE DEPENDENCIA -> INIT
        private readonly AdventureWorks2019Context context;

        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        //SELECT
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Department.ToList();
        }

        //SELECT BY ID
        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var department = (from d in context.Department
                              where d.DepartmentId == id
                              select d).SingleOrDefault();
            return department;
        }

        //SELECT BY NAME
        [HttpGet("name/{name}")]
        public ActionResult<Department> GetByName(string name)
        {
            var department = (from d in context.Department
                              where d.Name == name
                              select d).SingleOrDefault();
            return department;
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Department d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Department.Add(d);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Department d)
        {
            if (id != d.DepartmentId)
            {
                return BadRequest();
            }

            context.Entry(d).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE        
        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(int id)
        {
            var department = (from d in context.Department
                              where d.DepartmentId == id
                              select d).SingleOrDefault();

            if (department == null)
            {
                return NotFound();
            }

            context.Department.Remove(department);
            context.SaveChanges();

            return department;
        }
    }
}
