using SupportWheelOfFate.Dto;

namespace SupportWheelOfFate.Services
{
    public interface IRotaProcessorService
    {
        Task<IEnumerable<string>> GenerateRotaAsync(List<Engineer> engineers);
        Task<IEnumerable<string>> EngineersFetchAsync();
    }
}