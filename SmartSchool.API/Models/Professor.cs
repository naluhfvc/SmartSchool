﻿namespace SmartSchool.API.Modelss
{
    public class Professor
    {
        public Professor() { }

        public Professor(int id, 
                         int registro, 
                         string nome, 
                         string sobrenome,
                         string telefone
                         )
        {
            Id = id;
            Registro = registro;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }

        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
