using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("ninja")]
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

    }
}
