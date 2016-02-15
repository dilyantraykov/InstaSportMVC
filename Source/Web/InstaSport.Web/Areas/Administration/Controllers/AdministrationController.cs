namespace InstaSport.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using InstaSport.Common;
    using InstaSport.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
