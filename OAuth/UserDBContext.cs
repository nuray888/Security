using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OAuth.Entities;

namespace OAuth
{
    public class UserDBContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        public UserDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<User> users { get; set; }
    }
}
