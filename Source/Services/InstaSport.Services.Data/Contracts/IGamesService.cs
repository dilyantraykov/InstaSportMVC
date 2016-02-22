﻿namespace InstaSport.Services.Data
{
    using System.Linq;
    using InstaSport.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetUpcoming();

        IQueryable<Game> GetByCity(int cityId);

        int GetCount();

        Game GetById(int id);

        int AddPlayer(int gameId, User player);

        int Create(Game game);
    }
}
