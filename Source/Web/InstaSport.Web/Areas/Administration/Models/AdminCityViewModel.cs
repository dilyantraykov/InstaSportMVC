namespace InstaSport.Web.Areas.Administration.Models
{
    using System;
    using InstaSport.Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class AdminCityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
