using SupportWheelOfFate.Dto;
using SupportWheelOfFate.Repository;
using SupportWheelOfFate.Services;

namespace SupportWheelOfFate.Tests.Services
{
    [TestClass]
    public class RotaProcessorServiceTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Mock<IRotaRepository> _rotaRepository;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private List<string> _engineersNames = new()
        {
            "Tom Whitehall",
            "Timothy Spencer"
        };

        [TestInitialize]
        public void Initialise()
        {
            _rotaRepository = new Mock<IRotaRepository>();
        }

        IRotaProcessorService getService()
        {
            return new RotaProcessorService(_rotaRepository.Object);
        }

        [TestMethod]
        public async Task EngineersFetchAsyncTest()
        {
            _rotaRepository.Setup(x => x.EngineerFetchAsync()).ReturnsAsync(_engineersNames);
            var service = getService();
            var result = await service.EngineersFetchAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GenerateRotaAsyncTest()
        {
            var engineers = _engineersNames.Select(x => new Engineer(x)).ToList();

            var service = getService();

            await service.GenerateRotaAsync(engineers);
            _rotaRepository.Verify(x => x.RotaSaveAsync(It.IsAny<IEnumerable<Engineer>>()), Times.Once);
        }
    }
}
