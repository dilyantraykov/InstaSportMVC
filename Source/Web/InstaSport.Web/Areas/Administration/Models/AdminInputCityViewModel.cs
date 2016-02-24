namespace InstaSport.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AdminInputCityViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
