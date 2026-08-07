using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Common.FSFile.Queries;

public class FSFileDto : IDto
{
    public Guid Id { get; set; }
    public Guid FolderId { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
    public string? Hash { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}