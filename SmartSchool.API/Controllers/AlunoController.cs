using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Modelss;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno(){
                Id = 1,
                Nome= "Patricia",
                Sobrenome= "Mendes",
                Telefone = "2198789-2011"
            },
            new Aluno(){
                Id = 2,
                Nome= "Lucas",
                Sobrenome= "Rocha",
                Telefone = "2198119-2011"
            },
            new Aluno(){
                Id = 3,
                Nome= "Lemos",
                Sobrenome= "Cunha",
                Telefone = "2192011-0989"
            },
        };

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET api/<AlunoController>/byId?id=
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }
        
        // GET api/<AlunoController>/byName?nome=
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }  
        
        // POST api/<AlunoController>/
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            return Ok(aluno);
        }   
        
        // PUT api/<AlunoController>/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }   
               
        // PUT api/<AlunoController>/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);
        }   
        
        // DELETE api/<AlunoController>/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }

    }
}
