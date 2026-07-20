using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.CompanyProductWarranty.Queries
{
    public class CompanyProductWarrantyDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyProductId { get; set; }
        public int WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}