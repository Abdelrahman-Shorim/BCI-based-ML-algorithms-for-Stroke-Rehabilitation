using BCI_Project.Models;

namespace BCI_Project.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().Where(a => a.IsDeleted == false).ToList();
        }
        public T GetById(int id)
        {
            var x = _context.Set<T>().Find(id);
            if (x == null)
                return null;
            if (x.IsDeleted)
                return null;
            else
                return x;
        }
        public T Add(T entity)
        {
            var x = _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            var y = _context.Set<T>().Update(entity);
            return entity;
        }
        public T Delete(int id)
        {
            var entity = GetById(id);
            //_context.Set<T>().Remove(entity);
            entity.IsDeleted = true;
            Update(entity);
            entity = GetById(id);
            return entity;
        }

        //public T GetById(int id)
        //{
        //    return _context.Set<T>().Find(id);
        //}
        //public T Add(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //    return entity;
        //}

    }
}
