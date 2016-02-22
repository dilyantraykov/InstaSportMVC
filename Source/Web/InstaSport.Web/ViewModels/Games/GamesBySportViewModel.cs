using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaSport.Web.ViewModels.Games
{
    public class GamesBySportViewModel
    {
        public string SportName { get; set; }

        public ICollection<UpcomingGameViewModel> Games { get; set; }
    }
}