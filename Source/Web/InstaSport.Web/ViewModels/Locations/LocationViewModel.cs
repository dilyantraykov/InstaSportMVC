﻿namespace InstaSport.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using InstaSport.Data.Models;
    using InstaSport.Services.Web;
    using InstaSport.Web.Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }

        public double Rating { get; set; }

        public ICollection<Sport> AvailableSports { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Location/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Location, LocationViewModel>()
                .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Ratings.Any() ? x.Ratings.Average(v => v.Value) : 0));
        }
    }
}
