using InstaSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaSport.Data.Migrations
{
    public class SeedData
    {
        public List<City> Cities;
        public List<Sport> Sports;
        public List<Location> Locations;

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
        }
    }
}
