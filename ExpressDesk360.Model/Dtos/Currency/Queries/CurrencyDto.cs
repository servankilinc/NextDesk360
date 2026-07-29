using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Currency.Queries
{
    public class CurrencyDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}