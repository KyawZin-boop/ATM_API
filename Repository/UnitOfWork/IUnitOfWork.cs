using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ApplicationConfig;
using Repository.Repositories.IRepository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        ITransactionRepository Transaction { get; }
        IFileRepository Files { get; }
        AppSettings AppSettings { get; }
        Task<int> SaveChangesAsync();
    }
}
