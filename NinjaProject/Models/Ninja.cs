using System.ComponentModel.DataAnnotations;

namespace NinjaApplication.Models
{
    public class Ninja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Gold { get; set; }

        public List<InventoryItem> Inventory { get; set; }

        /*public int TotalStrength => Inventory?.Sum(item => item.Strength) ?? 0;
        public int TotalIntelligence => Inventory?.Sum(item => item.Intelligence) ?? 0;
        public int TotalAgility => Inventory?.Sum(item => item.Agility) ?? 0;
        public int TotalGoldValue => Inventory?.Sum(item => item.GoldValue) ?? 0;*/
    }
}
