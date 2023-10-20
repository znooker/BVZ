using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface ITransaction
    {
        Task CommitAsync();
        Task RollbackAsync();
        ITransaction BeginTransaction();
        Task<bool> Save();
    }
}
