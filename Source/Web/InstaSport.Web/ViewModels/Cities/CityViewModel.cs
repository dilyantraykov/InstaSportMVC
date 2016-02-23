namespace InstaSport.Web.ViewModels.Cities
{
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
