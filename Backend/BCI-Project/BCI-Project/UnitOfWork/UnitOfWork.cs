using BCI_Project.Models;
using BCI_Project.Repository;
using BCI_Project.Repository.Repo;

namespace BCI_Project.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        ////public IRepository<UserType> UserType { get; private set; }
        ////public IRepository<User> User { get; private set; }
        //public IRepository<PaymentMethod> PaymentMethod { get; private set; }
        //public IRepository<Order> Order { get; private set; }
        //public OrderDetailRepository OrderDetail { get; private set; }
        //public IRepository<Category> Category { get; private set; }
        //public IRepository<Product> Product { get; private set; }
        //public IRepository<Discount> Discount { get; private set; }
        public IRepository<Game> Game { get; private set; }
        public IRepository<GameType> GameType { get; private set; }
        public IRepository<GameMovements> GameMovement { get; private set; }
        public IRepository<Comments> Comment { get; private set; }
        public IRepository<DrPatients> DrPatients { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Game=new Repository<Game>(_context);
            GameType = new Repository<GameType>(_context);
            GameMovement = new Repository<GameMovements>(_context);
            Comment = new Repository<Comments>(_context);
            DrPatients = new Repository<DrPatients>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
