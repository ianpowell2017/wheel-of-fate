using SupportWheelOfFate.Dto;

namespace SupportWheelOfFate.Repository
{
    public class RotaRepository : IRotaRepository
    {
        public Task<IEnumerable<string>> EngineerFetchAsync()
        {
            List<string> list = new() {
                "Martin Fowler",
                "Scott Hanselman",
                "Anders Hejlsberg",
                "Mads Torgersen",
                "Jack Black",
                "Joe Costerino",
                "Billy McBride",
                "Kevin Hart",
                "James Bond",
                "Tom Cruise"
            };

            return Task.FromResult<IEnumerable<string>>(list);
        }

        public Task RotaSaveAsync(IEnumerable<Engineer> engineers)
        {
            return Task.CompletedTask;
        }
    }
}
