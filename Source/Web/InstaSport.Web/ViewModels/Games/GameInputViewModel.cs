namespace InstaSport.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using Data.Models;

    public class GameInputViewModel
    {
        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public DateTime StartingDateTime { get; set; }

        public IEnumerable<Sport> Sports { get; set; }

        public int SportId { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public int LocationId { get; set; }
    }
}