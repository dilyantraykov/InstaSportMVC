namespace InstaSport.Web.Routes.Tests
{
    using System.Web.Routing;
    using InstaSport.Web.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class GamesRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Games/ById/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<GamesController>(c => c.ById(1));
        }

        [Test]
        public void TestRouteBySport()
        {
            const string Url = "/Games/BySport/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<GamesController>(c => c.BySport(1));
        }

        [Test]
        public void TestRouteByCity()
        {
            const string Url = "/Games/ByCity/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<GamesController>(c => c.ByCity(1));
        }
    }
}
