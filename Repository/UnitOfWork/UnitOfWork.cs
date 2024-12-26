using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using Microsoft.Extensions.Options;
using Model.ApplicationConfig;
using Repository.Repositories.IRepository;
using Repository.Repositories.Repository;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            User = new UserRepository(context);
            AppSettings = appSettings.Value;
        }
        public IUserRepository User { get; set; }
        public AppSettings AppSettings { get; set; }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
