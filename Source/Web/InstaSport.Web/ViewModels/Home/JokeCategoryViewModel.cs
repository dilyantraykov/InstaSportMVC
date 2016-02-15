namespace InstaSport.Web.ViewModels.Home
{
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
