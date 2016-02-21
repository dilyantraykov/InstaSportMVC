namespace InstaSport.Services.Data
{
    using System;
    using System.Linq;
    using InstaSport.Data.Common;
    using InstaSport.Data.Models;

    public class RatingsService : IRatingsService
    {
        private readonly IDbRepository<PlayerRating> playerRatings;
        private readonly IDbRepository<LocationRating> locationRatings;

        public RatingsService(
            IDbRepository<PlayerRating> playerRatings,
            IDbRepository<LocationRating> locationRatings)
        {
            this.playerRatings = playerRatings;
            this.locationRatings = locationRatings;
        }

        public IQueryable<LocationRating> GetAllLocationRatings()
        {
            var ratings = this.locationRatings.All();

            return ratings;
        }

        public IQueryable<PlayerRating> GetAllPlayerRatings()
        {
            var ratings = this.playerRatings.All();

            return ratings;
        }
    }
}
