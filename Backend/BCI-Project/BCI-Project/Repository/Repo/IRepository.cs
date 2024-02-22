using BCI_Project.Models;

namespace BCI_Project.Repository.Repo
{
    public interface IRepository<T> where T : BaseModel
    {
        ICollection<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        T Update(T entity);
        T Delete(Guid id);
    }
}
