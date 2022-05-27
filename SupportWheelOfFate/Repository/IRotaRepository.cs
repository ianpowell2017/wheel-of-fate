using SupportWheelOfFate.Dto;

namespace SupportWheelOfFate.Repository
{
    public interface IRotaRepository
    {
        Task<IEnumerable<string>> EngineerFetchAsync();
        Task RotaSaveAsync(IEnumerable<Engineer> engineers);
    }
}
