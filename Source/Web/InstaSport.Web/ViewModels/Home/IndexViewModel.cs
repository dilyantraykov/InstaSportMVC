namespace InstaSport.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<LocationViewModel> Locations { get; set; }

        public IEnumerable<SportsViewModel> Sports { get; set; }
    }
}
