namespace InstaSport.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class GameInputViewModel
    {
        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        [Required]
        public DateTime StartingDateTime { get; set; }

        public IEnumerable<Sport> Sports { get; set; }

        [Required]
        public int SportId { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}