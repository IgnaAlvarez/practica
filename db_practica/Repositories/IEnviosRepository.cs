using db_practica.Data.Models;

namespace db_practica.Repositories
{
    public interface IEnviosRepository
    {
        List<TEnvio> GetAll(DateTime f1, DateTime f2);
        bool Update(int id);

        bool Create(TEnvio envio);
    }
}
