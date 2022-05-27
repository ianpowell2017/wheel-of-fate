using SupportWheelOfFate.Controllers;
using SupportWheelOfFate.Dto;
using SupportWheelOfFate.Model;
using SupportWheelOfFate.Services;

namespace SupportWheelOfFate.Tests.Controllers
{
    [TestClass]
    public class RotaControllerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Mock<IRotaProcessorService> _rotaGenerator;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Initialize()
        {
            _rotaGenerator = new Mock<IRotaProcessorService>();
        }

        RotaController getController()
        {
            return new RotaController(_rotaGenerator.Object);
        }

        [TestMethod]
        public async Task GetAsyncTest()
        {
            _rotaGenerator.Setup(x => x.EngineersFetchAsync()).ReturnsAsync(new[] { "Tom" });
            var controller = getController();
            var response = await controller.GetAsync();
            Assert.IsNotNull(response)                ;
            Assert.AreEqual(1, response.Count());
        }

        [TestMethod]
        public async Task PostAsyncTest()
        {
            var model = new EngineerModel
            {
                Engineers = new List<Engineer>
                {
                    new Engineer("Tom")
                }
            };

            _rotaGenerator.Setup(x => x.GenerateRotaAsync(It.IsAny<List<Engineer>>())).ReturnsAsync(model.Engineers.Select(x => x.Name));
            var controller = getController();
            var response = await controller.PostAsync(model);
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
        }
    }
}
