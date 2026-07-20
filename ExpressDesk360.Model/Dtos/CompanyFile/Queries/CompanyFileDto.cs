using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.CompanyFile.Queries
{
    public class CompanyFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid FileId { get; set; }
    }
}