namespace InstaSport.Web.ViewModels.Home
{
    using AutoMapper;
    using InstaSport.Data.Models;
    using InstaSport.Services.Web;
    using InstaSport.Web.Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Location/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}
