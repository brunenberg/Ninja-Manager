using System.ComponentModel.DataAnnotations;

namespace NinjaApplication.Models
{
    public class Gear
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GoldValue { get; set; }

        [Required]
        public EquipmentCategory Category { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Strength { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Intelligence { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Agility { get; set; }

        public List<InventoryItem> Ninjas { get; set; }

    }
}
