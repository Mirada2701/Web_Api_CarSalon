using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarSalonDbContext>(opt => opt.UseSqlServer(connectionString));

        }
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
              options.SignIn.RequireConfirmedAccount = false)
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<CarSalonDbContext>();


        }

    }
}
