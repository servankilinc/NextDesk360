using AutoMapper;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStatus.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStatus.Commands;

namespace ExpressDesk360.Business.Mappings;

public class TaskModuleMappingProfiles : Profile
{
    public TaskModuleMappingProfiles()
    {
        CreateMap<_Task, _Task>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<_Task, TaskDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskPriorityId, opt => opt.MapFrom(src => src.TaskPriorityId)).ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId)).ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.LastTaskMovementTypeId, opt => opt.MapFrom(src => src.LastTaskMovementTypeId)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskCreateDto, _Task>().ForMember(dest => dest.TaskPriorityId, opt => opt.MapFrom(src => src.TaskPriorityId)).ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId)).ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.LastTaskMovementTypeId, opt => opt.MapFrom(src => src.LastTaskMovementTypeId)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<TaskUpdateDto, _Task>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskPriorityId, opt => opt.MapFrom(src => src.TaskPriorityId)).ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId)).ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.LastTaskMovementTypeId, opt => opt.MapFrom(src => src.LastTaskMovementTypeId)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<TaskFile, TaskFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskFile, TaskFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskFileCreateDto, TaskFile>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
        CreateMap<TaskFileUpdateDto, TaskFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();

        CreateMap<TaskMovement, TaskMovement>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskMovement, TaskMovementDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.TaskMovementTypeId, opt => opt.MapFrom(src => src.TaskMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskMovementCreateDto, TaskMovement>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.TaskMovementTypeId, opt => opt.MapFrom(src => src.TaskMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<TaskMovementUpdateDto, TaskMovement>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.TaskMovementTypeId, opt => opt.MapFrom(src => src.TaskMovementTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<TaskMovementType, TaskMovementType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskMovementType, TaskMovementTypeDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.TaskStatusId, opt => opt.MapFrom(src => src.TaskStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskMovementTypeCreateDto, TaskMovementType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.TaskStatusId, opt => opt.MapFrom(src => src.TaskStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<TaskMovementTypeUpdateDto, TaskMovementType>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.TaskStatusId, opt => opt.MapFrom(src => src.TaskStatusId)).ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => src.Accessible)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.InformationText, opt => opt.MapFrom(src => src.InformationText)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<TaskPriority, TaskPriority>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskPriority, TaskPriorityDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskPriorityCreateDto, TaskPriority>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value)).ReverseMap();
        CreateMap<TaskPriorityUpdateDto, TaskPriority>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value)).ReverseMap();

        CreateMap<TaskStaff, TaskStaff>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskStaff, TaskStaffDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskStaffCreateDto, TaskStaff>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ReverseMap();
        CreateMap<TaskStaffUpdateDto, TaskStaff>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate)).ReverseMap();

        CreateMap<_TaskStatus, _TaskStatus>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<_TaskStatus, TaskStatusDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<TaskStatusCreateDto, _TaskStatus>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<TaskStatusUpdateDto, _TaskStatus>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
    }
}
