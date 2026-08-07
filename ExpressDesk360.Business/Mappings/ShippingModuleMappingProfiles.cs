using AutoMapper;
using ExpressDesk360.Model.Dtos.ShippingModule.CargoCompany.Commands;
using ExpressDesk360.Model.Dtos.ShippingModule.CargoCompany.Queries;
using ExpressDesk360.Model.Dtos.ShippingModule.Shipping.Commands;
using ExpressDesk360.Model.Dtos.ShippingModule.Shipping.Queries;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Commands;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Queries;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingType.Commands;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingType.Queries;
using ExpressDesk360.Model.Entities.ShippingModule;

namespace ExpressDesk360.Business.Mappings;

public class ShippingModuleMappingProfiles : Profile
{
    public ShippingModuleMappingProfiles()
    {
        CreateMap<Shipping, Shipping>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Shipping, ShippingDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CargoCompanyId, opt => opt.MapFrom(src => src.CargoCompanyId)).ForMember(dest => dest.ShippingTypeId, opt => opt.MapFrom(src => src.ShippingTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.SendingCompanyName, opt => opt.MapFrom(src => src.SendingCompanyName)).ForMember(dest => dest.ReceivingCompanyName, opt => opt.MapFrom(src => src.ReceivingCompanyName)).ForMember(dest => dest.IsIncoming, opt => opt.MapFrom(src => src.IsIncoming)).ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber)).ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate)).ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ForMember(dest => dest.PriceCurrencyId, opt => opt.MapFrom(src => src.PriceCurrencyId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ShippingCreateDto, Shipping>().ForMember(dest => dest.CargoCompanyId, opt => opt.MapFrom(src => src.CargoCompanyId)).ForMember(dest => dest.ShippingTypeId, opt => opt.MapFrom(src => src.ShippingTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.SendingCompanyName, opt => opt.MapFrom(src => src.SendingCompanyName)).ForMember(dest => dest.ReceivingCompanyName, opt => opt.MapFrom(src => src.ReceivingCompanyName)).ForMember(dest => dest.IsIncoming, opt => opt.MapFrom(src => src.IsIncoming)).ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber)).ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate)).ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ForMember(dest => dest.PriceCurrencyId, opt => opt.MapFrom(src => src.PriceCurrencyId)).ReverseMap();
        CreateMap<ShippingUpdateDto, Shipping>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CargoCompanyId, opt => opt.MapFrom(src => src.CargoCompanyId)).ForMember(dest => dest.ShippingTypeId, opt => opt.MapFrom(src => src.ShippingTypeId)).ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(dest => dest.SendingCompanyName, opt => opt.MapFrom(src => src.SendingCompanyName)).ForMember(dest => dest.ReceivingCompanyName, opt => opt.MapFrom(src => src.ReceivingCompanyName)).ForMember(dest => dest.IsIncoming, opt => opt.MapFrom(src => src.IsIncoming)).ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber)).ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate)).ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ForMember(dest => dest.PriceCurrencyId, opt => opt.MapFrom(src => src.PriceCurrencyId)).ReverseMap();

        CreateMap<ShippingFile, ShippingFile>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ShippingFile, ShippingFileDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ShippingId, opt => opt.MapFrom(src => src.ShippingId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ShippingFileCreateDto, ShippingFile>().ForMember(dest => dest.ShippingId, opt => opt.MapFrom(src => src.ShippingId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();
        CreateMap<ShippingFileUpdateDto, ShippingFile>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ShippingId, opt => opt.MapFrom(src => src.ShippingId)).ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.FileId)).ReverseMap();

        CreateMap<ShippingType, ShippingType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ShippingType, ShippingTypeDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<ShippingTypeCreateDto, ShippingType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<ShippingTypeUpdateDto, ShippingType>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        CreateMap<CargoCompany, CargoCompany>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CargoCompany, CargoCompanyDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CargoCompanyCreateDto, CargoCompany>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
        CreateMap<CargoCompanyUpdateDto, CargoCompany>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
    }
}

