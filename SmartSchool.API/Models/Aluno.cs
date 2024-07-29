using System.Collections.Generic;

namespace SmartSchool.API.Modelss
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(int id, 
                     int matricula,
                     string nome, 
                     string sobrenome, 
                     string telefone, 
                     DateTime dataNasc)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNasc = dataNasc;
        }

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina>? AlunosDisciplinas { get; set; } 
    }
}
