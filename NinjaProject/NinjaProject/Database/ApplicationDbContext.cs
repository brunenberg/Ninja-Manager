using Microsoft.EntityFrameworkCore;
using NinjaApplication.Models;

namespace NinjaProject.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Gear> Gears { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InventoryItem>(entity =>
            {
                entity.HasOne(x => x.Ninja)
                .WithMany(e => e.Inventory)
                .HasForeignKey(x => x.NinjaId);

                entity.HasOne(x => x.Gear)
                .WithMany(e => e.Ninjas)
                .HasForeignKey(x => x.GearId);
            });
        }
    }
}