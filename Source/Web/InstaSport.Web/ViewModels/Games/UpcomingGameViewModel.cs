namespace InstaSport.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using InstaSport.Data.Models;

    public class UpcomingGameViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public string SportName { get; set; }

        public DateTime StartingDateTime { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Game, UpcomingGameViewModel>()
                .ForMember(
                    x => x.LocationName,
                    opt => opt.MapFrom(x => x.Location.Name))
                .ForMember(
                    x => x.SportName,
                    opt => opt.MapFrom(x => x.Sport.Name));
        }
    }
}
