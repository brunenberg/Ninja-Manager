using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("gear")]
    public class Gear
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Column("goldvalue")]
        public int GoldValue { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        [Column("strength")]
        public int Strength { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        [Column("intelligence")]
        public int Intelligence { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        [Column("agility")]
        public int Agility { get; set; }

        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public GearCategory? Category { get; set; }


        public List<InventoryItem>? Ninjas { get; set; }
    }
}
