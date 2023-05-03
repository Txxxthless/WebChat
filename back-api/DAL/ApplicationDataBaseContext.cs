using back_api.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace back_api.DAL
{
    public class ApplicationDataBaseContext : IdentityDbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationDataBaseContext(
            DbContextOptions<ApplicationDataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
