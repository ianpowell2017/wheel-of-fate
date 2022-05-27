using Microsoft.AspNetCore.Mvc;
using SupportWheelOfFate.Model;
using SupportWheelOfFate.Services;

namespace SupportWheelOfFate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RotaController : ControllerBase
    {
        private IRotaProcessorService _rotaGenerator;

        public RotaController(IRotaProcessorService rotaGenerator)
        {
            _rotaGenerator = rotaGenerator;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var engineerNames = await _rotaGenerator.EngineersFetchAsync();
            return engineerNames;
        }

        [HttpPost]
        public async Task<IEnumerable<string>> PostAsync(EngineerModel model)
        {
            var rota = await _rotaGenerator.GenerateRotaAsync(model.Engineers);
            return rota;
        }
    }
}