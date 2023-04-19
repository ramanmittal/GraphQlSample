using GQLDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GQLDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull]DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasMany(p => p.Commands).WithOne(x => x.Platform).HasForeignKey(x=>x.PlatformId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
