using AutoMapper;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectStatus.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectStatus.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectFile.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectFile.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectStaff.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectStaff.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovement.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovement.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.Project.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.Project.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovementType.Commands;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovementType.Queries;
using ExpressDesk360.Model.Entities.ProjectModule;

namespace ExpressDesk360.Business.Mappings;

public class ProjectModuleMappingProfiles : Profile
{
    public ProjectModuleMappingProfiles()
    {
        CreateMap<Project, Project>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Project, ProjectDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectCreateDto, Project>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<ProjectUpdateDto, Project>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<ProjectFile, ProjectFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectFile, ProjectFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectFileCreateDto, ProjectFile>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
        CreateMap<ProjectFileUpdateDto, ProjectFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();

        CreateMap<ProjectMovement, ProjectMovement>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectMovement, ProjectMovementDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.ProjectMovementTypeId, opt => opt.MapFrom(src => src.ProjectMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectMovementCreateDto, ProjectMovement>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.ProjectMovementTypeId, opt => opt.MapFrom(src => src.ProjectMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<ProjectMovementUpdateDto, ProjectMovement>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.ProjectMovementTypeId, opt => opt.MapFrom(src => src.ProjectMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<ProjectMovementType, ProjectMovementType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectMovementType, ProjectMovementTypeDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProjectStatusId, opt => opt.MapFrom(src => src.ProjectStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectMovementTypeCreateDto, ProjectMovementType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProjectStatusId, opt => opt.MapFrom(src => src.ProjectStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<ProjectMovementTypeUpdateDto, ProjectMovementType>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProjectStatusId, opt => opt.MapFrom(src => src.ProjectStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<ProjectStaff, ProjectStaff>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectStaff, ProjectStaffDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectStaffCreateDto, ProjectStaff>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ReverseMap();
        CreateMap<ProjectStaffUpdateDto, ProjectStaff>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ReverseMap();

        CreateMap<ProjectStatus, ProjectStatus>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectStatus, ProjectStatusDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ProjectStatusCreateDto, ProjectStatus>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<ProjectStatusUpdateDto, ProjectStatus>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
    }
}