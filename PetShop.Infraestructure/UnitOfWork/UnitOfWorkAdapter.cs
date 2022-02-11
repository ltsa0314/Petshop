using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PetShop.Domain.SeedWork.Contracts;
using PetShop.Infraestructure.Data;
using System;

namespace PetShop.Infraestructure.UnitOfWork
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private bool _disposed = false;
        private readonly PetShopContext _context;
        private readonly IDbContextTransaction _transaction;
        public IUnitOfWorkRepositories Repositories { get; }

        public UnitOfWorkAdapter(PetShopContext context)
        {
            _context = context;
            if (!_context.Database.IsInMemory())
            {
                _transaction = _context.Database.BeginTransaction();
            }
            Repositories = new UnitOfWorkRepositories(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }


            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();

            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }
    }
}
