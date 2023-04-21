using back_api.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace back_api.DAL
{
    public class ApplicationDataBaseContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationDataBaseContext(
            DbContextOptions<ApplicationDataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
