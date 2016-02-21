namespace InstaSport.Web.ViewModels.Games
{
    using System.Linq;
    using AutoMapper;
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class PlayerViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, PlayerViewModel>()
                .ForMember(
                        x => x.Rating,
                        opt => opt.MapFrom(x => x.Ratings.Any() ? x.Ratings.Average(v => v.Value) : 0));
        }
    }
}
