using System;

namespace InstaSport.Web.Areas.Administration.Models
{
    public class AdminInputGameViewModel
    {
        public int Id { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public DateTime StartingDateTime { get; set; }
    }
}