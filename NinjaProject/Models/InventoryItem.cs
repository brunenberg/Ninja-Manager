using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("inventory_item")]
    public class InventoryItem
    {
        [Key]
        [Column("ninja_id")]
        public int NinjaId { get; set; }
        public Ninja Ninja { get; set; }

        [Key]
        [Column("gear_id")]
        public int GearId { get; set; }
        public Gear Gear { get; set; }

        public int PricePaid { get; set; }
    }
}
