using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("gear")]
    [PrimaryKey("Id")]
    public class Gear
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Column("goldvalue")]
        public int GoldValue { get; set; }

        [Required]
        [Column("category")]
        public GearCategory Category { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Column("strength")]
        public int Strength { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Column("intelligence")]
        public int Intelligence { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Column("agility")]
        public int Agility { get; set; }

        public List<InventoryItem>? Ninjas { get; set; }

    }
}
