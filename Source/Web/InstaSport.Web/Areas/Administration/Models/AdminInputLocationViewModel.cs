namespace InstaSport.Web.Areas.Administration.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using InstaSport.Data.Models;

    public class AdminInputLocationViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}
