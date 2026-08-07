using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Common.FSFolder.Commands;

public class FSFolderUpdateDto : IDto
{
    public Guid Id { get; set; }
    public Guid? OwnerId { get; set; }
    public Guid? ParentFolderId { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
}

public class FSFolderUpdateDtoValidator : AbstractValidator<FSFolderUpdateDto>
{
    public FSFolderUpdateDtoValidator()
    {
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        RuleFor(v => v.Path).NotEmpty().WithMessage("Path cannot be empty");
        RuleFor(v => v.Path).MaximumLength(500).WithMessage("Path cannot exceed 500 characters");
    }
}