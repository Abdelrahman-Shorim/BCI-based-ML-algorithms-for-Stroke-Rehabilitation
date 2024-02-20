using BCI_Project.Models;

namespace BCI_Project.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
