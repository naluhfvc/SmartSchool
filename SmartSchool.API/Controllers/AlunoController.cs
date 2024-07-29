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
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);

            return Ok(result);
        }

        // GET api/<AlunoController>/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        // POST api/<AlunoController>/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);
            
            return BadRequest("Erro ao cadastrar aluno.");
        }

        // PUT api/<AlunoController>/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoDB = _repo.GetAlunoById(id);
            if (alunoDB == null) return NotFound("Aluno não encontrado.");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Erro ao atualizar aluno.");
        }

        // PUT api/<AlunoController>/id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoDB = _repo.GetAlunoById(id);
            if (alunoDB == null) return NotFound("Aluno não encontrado.");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Erro ao atualizar aluno.");
        }

        // DELETE api/<AlunoController>/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return NotFound("Aluno não encontrado.");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
                return Ok("Sucesso ao deletar aluno.");

            return BadRequest("Erro ao deletar aluno.");
        }

    }
}
