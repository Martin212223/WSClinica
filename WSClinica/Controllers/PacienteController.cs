using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DBClinicaContext context;

        public PacienteController(DBClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            Paciente paciente = (from pcnte in context.Pacientes where pcnte.Id == id select pcnte).SingleOrDefault();

            return paciente;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Paciente paciente)
        {
            if (id != paciente.Id) {
                return BadRequest();
            }

            context.Entry(paciente).State = EntityState.Modified;

            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Pacientes.Add(paciente);

            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {
            var paciente = (from pcnte in context.Pacientes where pcnte.Id == id select pcnte).SingleOrDefault();

            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);

            context.SaveChanges();

            return paciente;
        }
    }
}
