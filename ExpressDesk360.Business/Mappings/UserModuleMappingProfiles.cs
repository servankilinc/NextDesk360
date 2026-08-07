using AutoMapper;
using ExpressDesk360.Model.Auth.SignUp;
using ExpressDesk360.Model.Dtos.UserModule.User.Commands;
using ExpressDesk360.Model.Dtos.UserModule.User.Queries;
using ExpressDesk360.Model.Dtos.UserModule.UserContact.Commands;
using ExpressDesk360.Model.Dtos.UserModule.UserContact.Queries;
using ExpressDesk360.Model.Dtos.UserModule.UserFile.Commands;
using ExpressDesk360.Model.Dtos.UserModule.UserFile.Queries;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Business.Mappings;

public class UserModuleMappingProfiles : Profile
{
    public UserModuleMappingProfiles()
    {
        CreateMap<SignUpRequest, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).ReverseMap();

        CreateMap<User, User>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<User, UserDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName)).ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UserCreateDto, User>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName)).ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ReverseMap();
        CreateMap<UserUpdateDto, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName)).ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ReverseMap();

        CreateMap<UserContact, UserContact>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UserContact, UserContactDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UserContactCreateDto, UserContact>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ReverseMap();
        CreateMap<UserContactUpdateDto, UserContact>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ReverseMap();

        CreateMap<UserFile, UserFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UserFile, UserFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UserFileCreateDto, UserFile>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
        CreateMap<UserFileUpdateDto, UserFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
    }
}
