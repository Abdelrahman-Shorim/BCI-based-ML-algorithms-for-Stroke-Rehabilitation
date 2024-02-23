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

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Game=new Repository<Game>(_context);
            GameType = new Repository<GameType>(_context);

            ///* UserType = new Repository<UserType>(_context);
            // User = new Repository<User>(_context);*/
            //PaymentMethod = new Repository<PaymentMethod>(_context);
            //Order = new Repository<Order>(_context);
            //OrderDetail = new OrderDetailRepository(_context);
            //Category = new Repository<Category>(_context);
            //Product = new Repository<Product>(_context);
            //Discount = new Repository<Discount>(_context);

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
