using SupportWheelOfFate.Dto;
using System.Diagnostics.CodeAnalysis;

namespace SupportWheelOfFate.Model
{
    [ExcludeFromCodeCoverage]
    public record EngineerModel
    {
        public List<Engineer> Engineers { get; init; } = new List<Engineer>();
    }
}