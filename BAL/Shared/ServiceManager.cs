using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IServices;
using BAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.ApplicationConfig;
using Repository.UnitOfWork;

namespace BAL.Shared
{
    public class ServiceManager
    {
        public static void SetServiceInfo(IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContextPool<DataContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
