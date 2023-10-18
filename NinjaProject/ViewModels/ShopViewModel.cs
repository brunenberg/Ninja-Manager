namespace NinjaProject.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<NinjaApplication.Models.Gear> GearList { get; set; }
        public NinjaApplication.Models.Ninja Ninja { get; set; }
    }

}
