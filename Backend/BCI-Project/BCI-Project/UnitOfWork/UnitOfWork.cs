﻿using BCI_Project.Models;
using BCI_Project.Repository;
using BCI_Project.Repository.Repo;
using BCI_Project.ViewModels;

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
        public IRepository<SignalsAdaptation> SignalsAdaptation { get; private set; }
        public IRepository<Attributes> Attributes { get; private set; }
        public IRepository<RoleAttributes> RoleAttributes { get; private set; }
        public IRepository<RoleAttributeValue> RoleAttributeValue { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Game=new Repository<Game>(_context);
            GameType = new Repository<GameType>(_context);
            GameMovement = new Repository<GameMovements>(_context);
            Comment = new Repository<Comments>(_context);
            DrPatients = new Repository<DrPatients>(_context);
            SignalsAdaptation = new Repository<SignalsAdaptation>(_context);
            Attributes = new Repository<Attributes>(_context);
            RoleAttributes = new Repository<RoleAttributes>(_context);
            RoleAttributeValue = new Repository<RoleAttributeValue>(_context);

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
