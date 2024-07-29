using SmartSchool.API.Models;

namespace SmartSchool.API.Modelss
{
    public class Disciplina
    {
        public Disciplina() { }

        public Disciplina(int id, string nome, int cargaHoraria, int professorId, int cursoId)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ProfessorId = professorId;
            CursoId = cursoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PreReqId { get; set; } = null;
        public Disciplina PreReq { get; set; } 
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public int CursoId { get; set; }
        public Curso curso { get; set; }
    }
}
