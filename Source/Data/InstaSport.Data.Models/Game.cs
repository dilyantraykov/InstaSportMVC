namespace InstaSport.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Game : BaseModel<int>
    {
        public Game()
        {
            this.Players = new HashSet<User>();
        }

        [Required]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public virtual ICollection<User> Players { get; set; }
    }
}
