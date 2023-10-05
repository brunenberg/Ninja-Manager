namespace NinjaApplication.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public int NinjaId { get; set; }
        public Ninja Ninja { get; set; }
        public int GearId { get; set; }
        public Gear Gear { get; set; }
    }
}
