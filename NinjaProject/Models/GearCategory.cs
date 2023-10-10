using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaApplication.Models
{
    [Table("gear_category")]
    public class GearCategory
    {
        [Key]
        [Column("category")]
        public string Category { get; set; }
    }
}