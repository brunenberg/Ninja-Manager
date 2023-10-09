using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("inventory_item")]
    [PrimaryKey("NinjaId", "GearId")]
    public class InventoryItem
    {
        [Key]
        public int NinjaId { get; set; }
        public Ninja Ninja { get; set; }

        [Key]
        [Column("Gear_id")]
        public int GearId { get; set; }
        public Gear Gear { get; set; }
    }
}
