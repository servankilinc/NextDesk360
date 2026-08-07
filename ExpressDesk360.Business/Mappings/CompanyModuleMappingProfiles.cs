using AutoMapper;
using ExpressDesk360.Model.Dtos.CompanyModule.Company.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.Company.Queries;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Queries;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyContact.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyContact.Queries;
using ExpressDesk360.Model.Entities.CompanyModule;

namespace ExpressDesk360.Business.Mappings;

public class CompanyModuleMappingProfiles : Profile
{
    public CompanyModuleMappingProfiles()
    {
        CreateMap<Company, Company>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Company, CompanyDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ManagerApproval, opt => opt.MapFrom(src => src.ManagerApproval)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyCreateDto, Company>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ManagerApproval, opt => opt.MapFrom(src => src.ManagerApproval)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ReverseMap();
        CreateMap<CompanyUpdateDto, Company>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ManagerApproval, opt => opt.MapFrom(src => src.ManagerApproval)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl)).ReverseMap();

        CreateMap<CompanyContact, CompanyContact>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyContact, CompanyContactDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyContactCreateDto, CompanyContact>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ReverseMap();
        CreateMap<CompanyContactUpdateDto, CompanyContact>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => src.ContactTypeId)).ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info)).ReverseMap();

        CreateMap<CompanyFile, CompanyFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyFile, CompanyFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyFileCreateDto, CompanyFile>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
        CreateMap<CompanyFileUpdateDto, CompanyFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
    }
}
