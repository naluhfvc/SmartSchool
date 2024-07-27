using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Modelss;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        public readonly SmartContext _context;

        public Repository()
        {
            
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(aluno);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public string pegaResposta()
        {
            return "Implementado";
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
