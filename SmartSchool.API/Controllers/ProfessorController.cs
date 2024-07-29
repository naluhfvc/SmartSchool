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
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores();

            return Ok(result);
        }

        // GET api/<ProfessorController>/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return NotFound("Professor não encontrado.");

            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao cadastrar professor.");
        }

        // PUT api/<ProfessorController>/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorDB = _repo.GetProfessorById(id);
            if (professorDB == null) return NotFound("Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }        
        
        // PATCH api/<ProfessorController>/id
        [HttpPut("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorDB = _repo.GetProfessorById(id);
            if (professorDB == null) return NotFound("Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }

        // DELETE api/<ProfessorController>/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return NotFound("Professor não encontrado.");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao deletar professor.");
        }
    }
}
