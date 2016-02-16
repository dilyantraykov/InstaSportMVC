namespace InstaSport.Web.Controllers.Tests
{
    using Moq;

    using InstaSport.Data.Models;
    using InstaSport.Services.Data;
    using InstaSport.Web.Infrastructure.Mapping;
    using InstaSport.Web.ViewModels.Home;

    using NUnit.Framework;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class LocationsControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(LocationsController).Assembly);
            const string LocationName = "SomeLocation";
            var locationsServiceMock = new Mock<ILocationsService>();
            locationsServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new Location { Name = LocationName });
            var controller = new LocationsController(locationsServiceMock.Object);
            controller.WithCallTo(x => x.ById("asdasasd"))
                .ShouldRenderView("ById")
                .WithModel<LocationViewModel>(
                    viewModel =>
                        {
                            Assert.AreEqual(LocationName, viewModel.Name);
                        }).AndNoModelErrors();
        }
    }
}
