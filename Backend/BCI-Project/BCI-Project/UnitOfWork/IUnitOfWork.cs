using BCI_Project.Models;
using BCI_Project.Repository;
using BCI_Project.Repository.Repo;

namespace BCI_Project.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Game { get; }
        IRepository<GameType> GameType { get; }
        IRepository<GameMovements> GameMovement { get; }
        IRepository<Comments> Comment { get; }
        IRepository<DrPatients> DrPatients { get; }
        IRepository<SignalsAdaptation> SignalsAdaptation { get; }
        IRepository<Attributes> Attributes { get; }

        IRepository<RoleAttributes> RoleAttributes { get; }
        IRepository<RoleAttributeValue> RoleAttributeValue { get; }


        int Save();
    }
}
