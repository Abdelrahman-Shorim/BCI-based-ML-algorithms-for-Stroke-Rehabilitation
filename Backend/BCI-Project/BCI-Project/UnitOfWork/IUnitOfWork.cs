using BCI_Project.Models;
using BCI_Project.Repository;
using BCI_Project.Repository.Repo;

namespace BCI_Project.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ////IRepository<UserType> UserType { get; }
        ////IRepository<User> User { get; }
        //IRepository<PaymentMethod> PaymentMethod { get; }
        //IRepository<Order> Order { get; }
        //OrderDetailRepository OrderDetail { get; }
        //IRepository<Category> Category { get; }
        //IRepository<Product> Product { get; }
        //IRepository<Discount> Discount { get; }

        IRepository<Game> Game { get; }
        int Save();
    }
}
