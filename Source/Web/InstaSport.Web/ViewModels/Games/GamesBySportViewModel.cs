﻿namespace InstaSport.Web.ViewModels.Games
{
    using System.Collections.Generic;

    public class GamesBySportViewModel
    {
        public string SportName { get; set; }

        public ICollection<UpcomingGameViewModel> Games { get; set; }
    }
}