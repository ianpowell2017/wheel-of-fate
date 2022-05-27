using SupportWheelOfFate.Dto;
using SupportWheelOfFate.Repository;

namespace SupportWheelOfFate.Services
{
    public class RotaProcessorService : IRotaProcessorService
    {
        private readonly IRotaRepository _rotaRepository;

        public RotaProcessorService(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<IEnumerable<string>> EngineersFetchAsync()
        {
            var engineers = await _rotaRepository.EngineerFetchAsync();
            return engineers;
        }

        public async Task<IEnumerable<string>> GenerateRotaAsync(List<Engineer> engineers)
        {
            var newRota = new Dictionary<Guid, Engineer>();
            engineers.ForEach(engineer => newRota.Add(Guid.NewGuid(), engineer));
            var engineerRota = newRota.OrderBy(x => x.Key).ToList();

            await _rotaRepository.RotaSaveAsync(engineerRota.Select(x => x.Value));
            return engineerRota.Select(x => x.Value.Name);
        }
    }
}
