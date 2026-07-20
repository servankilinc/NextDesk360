using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.FaultType.Queries
{
    public class FaultTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}