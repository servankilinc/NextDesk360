using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Common.FSFile.Commands;

public class FSFileCreateDto : IDto
{
    public Guid FolderId { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
    public string? Hash { get; set; }
    public DateTime? UpdateDate { get; set; }
}

public class FSFileCreateDtoValidator : AbstractValidator<FSFileCreateDto>
{
    public FSFileCreateDtoValidator()
    {
        RuleFor(v => v.FolderId).NotEqual(Guid.Empty).WithMessage("FolderId must be a valid guid value");
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        RuleFor(v => v.Path).NotEmpty().WithMessage("Path cannot be empty");
        RuleFor(v => v.Path).MaximumLength(500).WithMessage("Path cannot exceed 500 characters");
    }
}