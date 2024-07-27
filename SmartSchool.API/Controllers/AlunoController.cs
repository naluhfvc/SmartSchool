using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Modelss;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public readonly IRepository _repo;

        public AlunoController(SmartContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET api/<AlunoController>/byId?id=
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            return Ok(aluno);
        }

        // GET api/<AlunoController>/byName?nome=
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return NotFound("Aluno não encontrado");
            return Ok(aluno);
        }

        // POST api/<AlunoController>/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoDB = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunoDB == null) return NotFound("Aluno não encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoDB = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunoDB == null) return NotFound("Aluno não encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // DELETE api/<AlunoController>/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound("Aluno não encontrado.");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }

    }
}
