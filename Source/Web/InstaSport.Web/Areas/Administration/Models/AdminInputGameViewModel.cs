namespace InstaSport.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminInputGameViewModel
    {
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        [Required]
        public DateTime StartingDateTime { get; set; }
    }
}