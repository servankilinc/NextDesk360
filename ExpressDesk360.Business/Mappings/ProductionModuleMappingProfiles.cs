using AutoMapper;
using ExpressDesk360.Model.Dtos.ProductionModule.BOM.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.BOM.Queries;
using ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Queries;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Queries;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Queries;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductWarranty.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductWarranty.Queries;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Business.Mappings;

public class ProductionModuleMappingProfiles : Profile
{
    public ProductionModuleMappingProfiles()
    {
        CreateMap<BOM, BOM>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<BOM, BOMDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.VersionName)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<BOMCreateDto, BOM>().ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.VersionName)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ReverseMap();
        CreateMap<BOMUpdateDto, BOM>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.VersionName)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ReverseMap();

        CreateMap<BOMItem, BOMItem>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<BOMItem, BOMItemDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<BOMItemCreateDto, BOMItem>().ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)).ReverseMap();
        CreateMap<BOMItemUpdateDto, BOMItem>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)).ReverseMap();

        CreateMap<CompanyProduct, CompanyProduct>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProduct, CompanyProductDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProductCreateDto, CompanyProduct>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ReverseMap();
        CreateMap<CompanyProductUpdateDto, CompanyProduct>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)).ForMember(dest => dest.BOMId, opt => opt.MapFrom(src => src.BOMId)).ReverseMap();

        CreateMap<CompanyProductStockSerialMap, CompanyProductStockSerialMap>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProductStockSerialMap, CompanyProductStockSerialMapDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.StockSerialId, opt => opt.MapFrom(src => src.StockSerialId)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProductStockSerialMapCreateDto, CompanyProductStockSerialMap>().ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.StockSerialId, opt => opt.MapFrom(src => src.StockSerialId)).ReverseMap();
        CreateMap<CompanyProductStockSerialMapUpdateDto, CompanyProductStockSerialMap>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.StockSerialId, opt => opt.MapFrom(src => src.StockSerialId)).ReverseMap();

        CreateMap<CompanyProductWarranty, CompanyProductWarranty>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProductWarranty, CompanyProductWarrantyDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.WarrantyTypeId, opt => opt.MapFrom(src => src.WarrantyTypeId)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<CompanyProductWarrantyCreateDto, CompanyProductWarranty>().ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.WarrantyTypeId, opt => opt.MapFrom(src => src.WarrantyTypeId)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ReverseMap();
        CreateMap<CompanyProductWarrantyUpdateDto, CompanyProductWarranty>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.CompanyProductId, opt => opt.MapFrom(src => src.CompanyProductId)).ForMember(dest => dest.WarrantyTypeId, opt => opt.MapFrom(src => src.WarrantyTypeId)).ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate)).ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate)).ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).ReverseMap();
    }
}