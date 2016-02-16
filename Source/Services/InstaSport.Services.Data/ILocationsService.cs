﻿namespace InstaSport.Services.Data
{
    using System.Linq;

    using InstaSport.Data.Models;

    public interface ILocationsService
    {
        IQueryable<Location> GetAll();

        IQueryable<Location> GetLocationsByCity(int cityId);

        Location GetById(string id);
    }
}
