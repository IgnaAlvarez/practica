using db_practica.Data.Models;

namespace db_practica.Repositories
{
    public class EnviosRepository : IEnviosRepository
    {
        private EnviosDbContext _context;
        public EnviosRepository(EnviosDbContext context)
        {
            _context = context;
        }
        public bool Create(TEnvio envio)
        {
            _context.TEnvios.Add(envio);
            return _context.SaveChanges() == 1;
        }

        public List<TEnvio> GetAll(DateTime f1, DateTime f2)
        {
            return _context.TEnvios.Where(e => e.FechaEnvio >= f1 && e.FechaEnvio <= f2).ToList();

        }

        public bool Update(int id)
        {
            var envioExistente = _context.TEnvios.Find(id);
            if (envioExistente != null)
            {
                envioExistente.Estado = "cancelado";
                return true;
            }
            return false;
        }
    }
}
