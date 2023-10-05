using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NinjaApplication.Models;

namespace NinjaApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NinjaApplication.Models.Ninja>? Ninja { get; set; }
        public DbSet<NinjaApplication.Models.Gear>? Gear { get; set; }
        public DbSet<NinjaApplication.Models.InventoryItem>? InventoryItem { get; set; }
    }
}