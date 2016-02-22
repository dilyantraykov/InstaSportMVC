namespace InstaSport.Web.ViewModels.Sports
{
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class SportViewModel : IMapFrom<Sport>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
