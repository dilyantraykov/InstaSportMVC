namespace InstaSport.Web.ViewModels.Locations
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class LocationLinkViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        public string Name { get; set; }

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
