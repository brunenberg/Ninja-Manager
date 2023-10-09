using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("ninja")]
    [PrimaryKey("Id")]
    public class Ninja
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Column("gold")]
        public int Gold { get; set; }

        public List<InventoryItem>? Inventory { get; set; }

        /*public int TotalStrength => Inventory?.Sum(item => item.Strength) ?? 0;
        public int TotalIntelligence => Inventory?.Sum(item => item.Intelligence) ?? 0;
        public int TotalAgility => Inventory?.Sum(item => item.Agility) ?? 0;
        public int TotalGoldValue => Inventory?.Sum(item => item.GoldValue) ?? 0;*/
    }
}
