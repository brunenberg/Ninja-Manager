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
        public DbSet<GearCategory> GearCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(ii => new { ii.NinjaId, ii.GearId });

                entity.HasOne(ii => ii.Ninja)
                    .WithMany(n => n.Inventory)
                    .HasForeignKey(ii => ii.NinjaId);

                entity.HasOne(ii => ii.Gear)
                    .WithMany(g => g.Ninjas)
                    .HasForeignKey(ii => ii.GearId);
            });

            builder.Entity<Gear>(entity =>
            {
                entity.HasOne(g => g.Category)
                    .WithMany()
                    .HasForeignKey(g => g.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gear_GearCategory");
            });



            // Add other configurations as needed

            base.OnModelCreating(builder);

        }


    }
}