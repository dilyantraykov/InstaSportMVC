namespace InstaSport.Web.Areas.Administration.Models
{
    using System;
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class AdminGameViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public DateTime StartingDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}