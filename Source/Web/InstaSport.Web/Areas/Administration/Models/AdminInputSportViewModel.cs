using System.ComponentModel.DataAnnotations;

namespace InstaSport.Web.Areas.Administration.Models
{
    public class AdminInputSportViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
