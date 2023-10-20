using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class BaseRepository : ITransaction
    {
        protected readonly ZooDbContext _context;
        private IDbContextTransaction _transaction;

        public BaseRepository(ZooDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public ITransaction BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _context.Database.BeginTransaction();
            }
            return this;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

    }
}
