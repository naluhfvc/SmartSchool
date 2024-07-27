using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Modelss;
using SQLitePCL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GET api/<ProfessorController>/byId?id=
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound("Professor não encontrado.");

            return Ok(professor);
        }

        // GET api/<ProfessorController>/byName?name=
        [HttpGet("byname")]
        public IActionResult GetByName(string name)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(name));
            if (professor == null) return NotFound("Professor não encontrado.");

            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorDB = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (professorDB == null) return NotFound("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound("Professor não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
