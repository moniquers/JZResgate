using JZResgate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JZResgate.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecoveryTruck>().Property(t => t.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
