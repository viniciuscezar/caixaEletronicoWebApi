using CadastroCedulas.Data;
using CadastroCedulas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCedulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CedulaController : ControllerBase
    {
        public readonly Context _context;

        public CedulaController(Context context)
        {
            _context = context;
        }

        // GET: api/Cedula
        [HttpGet]
        public ActionResult Get()
        {
            var notas = _context.Cedulas.ToList();
            return Ok(notas);
        }

        // GET api/Cedula/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var cedulas = _context.Cedulas.FirstOrDefault(n => n.Id == id);

            if (cedulas == null)
                return BadRequest("Cedula não encontrada!");

            return Ok(cedulas);
        }

        // POST api/Cedula
        [HttpPost]
        public ActionResult Post(Cedula cedula)
        {
            _context.Add(cedula);
            _context.SaveChanges();

            return Ok(cedula);
        }

        // PUT api/Cedula/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Cedula cedula)
        {
            var cedulas = _context.Cedulas.FirstOrDefault(n => n.Id == id);

            if (cedulas == null)
                return BadRequest("Cedula não encontrada!");

            _context.Update(cedula);
            _context.SaveChanges();

            return Ok(cedula);
        }

        // DELETE api/Cedula/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cedulas = _context.Cedulas.FirstOrDefault(n => n.Id == id);

            if (cedulas == null)
                return BadRequest("Cedula não encontrada!");

            _context.Remove(cedulas);
            _context.SaveChanges();

            return Ok();
        }
    }
}
