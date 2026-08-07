using AutoMapper;
using ExpressDesk360.Model.Dtos.Common.Unit.Commands;
using ExpressDesk360.Model.Dtos.Common.Unit.Queries;
using ExpressDesk360.Model.Dtos.Common.Currency.Commands;
using ExpressDesk360.Model.Dtos.Common.Currency.Queries;
using ExpressDesk360.Model.Dtos.Common.FSFolder.Commands;
using ExpressDesk360.Model.Dtos.Common.FSFolder.Queries;
using ExpressDesk360.Model.Dtos.Common.ContactType.Commands;
using ExpressDesk360.Model.Dtos.Common.ContactType.Queries;
using ExpressDesk360.Model.Dtos.Common.FSFile.Commands;
using ExpressDesk360.Model.Dtos.Common.FSFile.Queries;
using ExpressDesk360.Model.Dtos.Common.WarrantyType.Commands;
using ExpressDesk360.Model.Dtos.Common.WarrantyType.Queries;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.Business.Mappings;

public class CommonMappingProfiles : Profile
{
    public CommonMappingProfiles()
    {
        // ContactType (Common)
        CreateMap<ContactType, ContactType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ContactType, ContactTypeDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ContactTypeCreateDto, ContactType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ReverseMap();
        CreateMap<ContactTypeUpdateDto, ContactType>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ReverseMap();


        // Currency (Common)
        CreateMap<Currency, Currency>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Currency, CurrencyDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CurrencyCreateDto, Currency>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ReverseMap();
        CreateMap<CurrencyUpdateDto, Currency>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon)).ReverseMap();


        // FSFile (Common)
        CreateMap<FSFile, FSFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<FSFile, FSFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.FolderId, opt => opt.MapFrom(src => src.FolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension)).ForMember(dest => dest.MimeType, opt => opt.MapFrom(src => src.MimeType)).ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size)).ForMember(dest => dest.Hash, opt => opt.MapFrom(src => src.Hash)).ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate)).ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<FSFileCreateDto, FSFile>().ForMember(dest => dest.FolderId, opt => opt.MapFrom(src => src.FolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension)).ForMember(dest => dest.MimeType, opt => opt.MapFrom(src => src.MimeType)).ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size)).ForMember(dest => dest.Hash, opt => opt.MapFrom(src => src.Hash)).ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow)).ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate)).ReverseMap();
        CreateMap<FSFileUpdateDto, FSFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.FolderId, opt => opt.MapFrom(src => src.FolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension)).ForMember(dest => dest.MimeType, opt => opt.MapFrom(src => src.MimeType)).ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size)).ForMember(dest => dest.Hash, opt => opt.MapFrom(src => src.Hash)).ForMember(dest => dest.CreateDate, opt => opt.Ignore()).ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate)).ReverseMap();

        // FSFolder (Common)
        CreateMap<FSFolder, FSFolder>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<FSFolder, FSFolderDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.ParentFolderId, opt => opt.MapFrom(src => src.ParentFolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<FSFolderCreateDto, FSFolder>().ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.ParentFolderId, opt => opt.MapFrom(src => src.ParentFolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow)).ReverseMap();
        CreateMap<FSFolderUpdateDto, FSFolder>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId)).ForMember(dest => dest.ParentFolderId, opt => opt.MapFrom(src => src.ParentFolderId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path)).ForMember(dest => dest.CreateDate, opt => opt.Ignore()).ReverseMap();


        // Unit (Common)
        CreateMap<Unit, Unit>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Unit, UnitDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<UnitCreateDto, Unit>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ReverseMap();
        CreateMap<UnitUpdateDto, Unit>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName)).ReverseMap();


        // WarrantyType (Common)
        CreateMap<WarrantyType, WarrantyType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<WarrantyType, WarrantyTypeDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<WarrantyTypeCreateDto, WarrantyType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<WarrantyTypeUpdateDto, WarrantyType>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
    }
}