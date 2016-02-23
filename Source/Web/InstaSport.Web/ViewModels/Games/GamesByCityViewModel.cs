namespace InstaSport.Web.ViewModels.Games
{
    using System.Collections.Generic;

    public class GamesByCityViewModel
    {
        public string CityName { get; set; }

        public ICollection<UpcomingGameViewModel> Games { get; set; }
    }
}
