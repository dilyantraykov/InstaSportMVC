namespace InstaSport.Services.Data
{
    using System;
    using System.Linq;

    using InstaSport.Data.Common;
    using InstaSport.Data.Models;
    using InstaSport.Services.Web;

    public class LocationsService : ILocationsService
    {
        private readonly IDbRepository<Location> locations;
        private readonly IIdentifierProvider identifierProvider;

        public LocationsService(IDbRepository<Location> locations, IIdentifierProvider identifierProvider)
        {
            this.locations = locations;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Location> GetAll()
        {
            return this.locations.All();
        }

        public Location GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var location = this.locations.GetById(intId);
            return location;
        }

        public IQueryable<Location> GetLocationsByCity(int cityId)
        {
            return this.locations.All().Where(l => l.CityId == cityId);
        }

        public double Rate(string userId, int locationId, int rating)
        {
            var location = this.locations.All().FirstOrDefault(x => x.Id == locationId);
            var currentRating = location.Ratings.FirstOrDefault(x => x.AuthorId == userId);

            if (currentRating == null)
            {
                location.Ratings.Add(new Rating
                {
                    AuthorId = userId,
                    Value = rating
                });
            }
            else
            {
                currentRating.Value = rating;
            }

            this.locations.Save();

            var newRating = location.Ratings.Average(x => x.Value);
            return newRating;
        }
    }
}
