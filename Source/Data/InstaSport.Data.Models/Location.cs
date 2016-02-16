namespace InstaSport.Data.Models
{
    using System.Collections.Generic;

    using InstaSport.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        public Location()
        {
            this.AvailableSports = new HashSet<Sport>();
        }

        public string Name { get; set; }

        public decimal Latitite { get; set; }

        public decimal Longitude { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public ICollection<Sport> AvailableSports { get; set; }
    }
}
