using AgendaApp.API.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Entity Framework

            var connectionString = configuration.GetConnectionString("BDAgendaApp");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            #endregion

            return services;
        }
    }
}
