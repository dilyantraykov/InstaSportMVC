namespace InstaSport.Web.Routes.Tests
{
    using System.Web.Routing;
    using InstaSport.Web.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class LocationsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Location/testid";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<LocationsController>(c => c.ById("testid"));
        }
    }
}
