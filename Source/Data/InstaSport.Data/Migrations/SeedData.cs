namespace InstaSport.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using InstaSport.Data.Models;

    public class SeedData
    {
        public List<City> Cities;
        public List<Sport> Sports;
        public List<Location> Locations;
        public List<Game> Games;

        public SeedData()
        {
            this.Cities = new List<City>()
                {
                    new City() { Name = "Sofia" },
                    new City() { Name = "Plovdiv" },
                    new City() { Name = "Varna" },
                    new City() { Name = "Burgas" }
                };

            this.Sports = new List<Sport>()
                {
                    new Sport() { Name = "Football" },
                    new Sport() { Name = "Tennis" },
                    new Sport() { Name = "Basketball" },
                    new Sport() { Name = "Billiards" }
                };

            this.Locations = new List<Location>()
                {
                    new Location() { Name = "Kompleks Simeonovo", City = this.Cities[0] }
                };
            this.Games = new List<Game>()
                {
                    new Game()
                    {
                        SportId = this.Sports[0].Id,
                        LocationId = this.Locations[0].Id,
                        StartingDateTime = DateTime.UtcNow.AddDays(6),
                        MinPlayers = 10,
                        MaxPlayers = 12
                    },
                    new Game()
                    {
                        SportId = this.Sports[1].Id,
                        LocationId = this.Locations[0].Id,
                        StartingDateTime = DateTime.UtcNow.AddDays(4),
                        MaxPlayers = 2
                    }
                };
        }
    }
}
