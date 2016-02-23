namespace InstaSport.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using InstaSport.Services.Data;
    using ViewModels.Sports;

    public class SportsController : BaseController
    {
        private ISportsService sports;

        public SportsController(ISportsService sports)
        {
            this.sports = sports;
        }

        public ActionResult Index()
        {
            var sports = this.Cache.Get(
                            "sports",
                            () => this.sports.GetAll().To<SportViewModel>().ToList(),
                            30 * 60);

            return this.View(sports);
        }
    }
}