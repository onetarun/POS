using Microsoft.EntityFrameworkCore;
using POS.API.Data;
using POS.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<POSContext>(options => options.UseSqlite(connectionString));
            services.AddSingleton<ITokenService, TokenService>();    
            
            
            
            return services;
        }

    }
}
