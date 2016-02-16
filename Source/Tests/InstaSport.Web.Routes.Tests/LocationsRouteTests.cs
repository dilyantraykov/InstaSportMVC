namespace InstaSport.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using InstaSport.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class LocationsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Location/Mjc2NS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<LocationsController>(c => c.ById("Mjc2NS4xMjMxMjMxMzEyMw=="));
        }
    }
}
