using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Commands
{
    public class ShippingFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ShippingId { get; set; }
        public Guid FileId { get; set; }
    }

    public class ShippingFileUpdateDtoValidator : AbstractValidator<ShippingFileUpdateDto>
    {
        public ShippingFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.ShippingId).NotEqual(Guid.Empty).WithMessage("ShippingId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}