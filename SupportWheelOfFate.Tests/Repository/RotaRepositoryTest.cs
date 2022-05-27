using SupportWheelOfFate.Dto;
using SupportWheelOfFate.Repository;

namespace SupportWheelOfFate.Tests.Repository
{
    [TestClass]
    public class RotaRepositoryTest
    {
        [TestMethod]
        public async Task EngineerFetchAsyncTest()
        {
            var repo = new RotaRepository();
            var result = await repo.EngineerFetchAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public async Task RotaSaveAsyncTest()
        {
            var repo = new RotaRepository();
            await repo.RotaSaveAsync(new Engineer[] { new Engineer("Tom") });
        }
    }
}
