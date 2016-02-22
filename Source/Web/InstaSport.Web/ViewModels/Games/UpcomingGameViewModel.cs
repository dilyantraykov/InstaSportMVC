namespace InstaSport.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using InstaSport.Data.Models;
    using Locations;
    using Sports;

    public class UpcomingGameViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public LocationLinkViewModel Location { get; set; }

        public SportViewModel Sport { get; set; }

        public DateTime StartingDateTime { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Game, UpcomingGameViewModel>()
                .ForMember(
                    x => x.Location,
                    opt => opt.MapFrom(x => x.Location))
                .ForMember(
                    x => x.Sport,
                    opt => opt.MapFrom(x => x.Sport));
        }
    }
}
