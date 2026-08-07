using AutoMapper;
using ExpressDesk360.Model.Dtos.InvoiceModule.Invoice.Commands;
using ExpressDesk360.Model.Dtos.InvoiceModule.Invoice.Queries;
using ExpressDesk360.Model.Dtos.InvoiceModule.InvoiceType.Commands;
using ExpressDesk360.Model.Dtos.InvoiceModule.InvoiceType.Queries;
using ExpressDesk360.Model.Entities.InvoiceModule;

namespace ExpressDesk360.Business.Mappings;

public class InvoiceModuleMappingProfiles : Profile
{
    public InvoiceModuleMappingProfiles()
    {
        CreateMap<Invoice, Invoice>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.InvoiceTypeId, opt => opt.MapFrom(src => src.InvoiceTypeId))
            .ForMember(dest => dest.InvoiceNo, opt => opt.MapFrom(src => src.InvoiceNo))
            .ForMember(dest => dest.ItemNumber, opt => opt.MapFrom(src => src.ItemNumber))
            .ForMember(dest => dest.SellerCompanyId, opt => opt.MapFrom(src => src.SellerCompanyId))
            .ForMember(dest => dest.BuyerCompanyId, opt => opt.MapFrom(src => src.BuyerCompanyId))
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
            .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.DiscountAmount1, opt => opt.MapFrom(src => src.DiscountAmount1))
            .ForMember(dest => dest.DiscountAmount2, opt => opt.MapFrom(src => src.DiscountAmount2))
            .ForMember(dest => dest.DiscountRate1, opt => opt.MapFrom(src => src.DiscountRate1))
            .ForMember(dest => dest.DiscountRate2, opt => opt.MapFrom(src => src.DiscountRate2))
            .ForMember(dest => dest.TaxTotal, opt => opt.MapFrom(src => src.TaxTotal))
            .ForMember(dest => dest.GrandTotal, opt => opt.MapFrom(src => src.GrandTotal))
            .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
            .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.ExchangeRate))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<InvoiceCreateDto, Invoice>()
            .ForMember(dest => dest.InvoiceTypeId, opt => opt.MapFrom(src => src.InvoiceTypeId))
            .ForMember(dest => dest.InvoiceNo, opt => opt.MapFrom(src => src.InvoiceNo))
            .ForMember(dest => dest.ItemNumber, opt => opt.MapFrom(src => src.ItemNumber))
            .ForMember(dest => dest.SellerCompanyId, opt => opt.MapFrom(src => src.SellerCompanyId))
            .ForMember(dest => dest.BuyerCompanyId, opt => opt.MapFrom(src => src.BuyerCompanyId))
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
            .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.DiscountAmount1, opt => opt.MapFrom(src => src.DiscountAmount1))
            .ForMember(dest => dest.DiscountAmount2, opt => opt.MapFrom(src => src.DiscountAmount2))
            .ForMember(dest => dest.DiscountRate1, opt => opt.MapFrom(src => src.DiscountRate1))
            .ForMember(dest => dest.DiscountRate2, opt => opt.MapFrom(src => src.DiscountRate2))
            .ForMember(dest => dest.TaxTotal, opt => opt.MapFrom(src => src.TaxTotal))
            .ForMember(dest => dest.GrandTotal, opt => opt.MapFrom(src => src.GrandTotal))
            .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
            .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.ExchangeRate))
            .ReverseMap();
        CreateMap<InvoiceUpdateDto, Invoice>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.InvoiceTypeId, opt => opt.MapFrom(src => src.InvoiceTypeId))
            .ForMember(dest => dest.InvoiceNo, opt => opt.MapFrom(src => src.InvoiceNo))
            .ForMember(dest => dest.ItemNumber, opt => opt.MapFrom(src => src.ItemNumber))
            .ForMember(dest => dest.SellerCompanyId, opt => opt.MapFrom(src => src.SellerCompanyId))
            .ForMember(dest => dest.BuyerCompanyId, opt => opt.MapFrom(src => src.BuyerCompanyId))
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
            .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.DiscountAmount1, opt => opt.MapFrom(src => src.DiscountAmount1))
            .ForMember(dest => dest.DiscountAmount2, opt => opt.MapFrom(src => src.DiscountAmount2))
            .ForMember(dest => dest.DiscountRate1, opt => opt.MapFrom(src => src.DiscountRate1))
            .ForMember(dest => dest.DiscountRate2, opt => opt.MapFrom(src => src.DiscountRate2))
            .ForMember(dest => dest.TaxTotal, opt => opt.MapFrom(src => src.TaxTotal))
            .ForMember(dest => dest.GrandTotal, opt => opt.MapFrom(src => src.GrandTotal))
            .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
            .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.ExchangeRate))
            .ReverseMap();


        CreateMap<InvoiceType, InvoiceType>().ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember)));
        CreateMap<InvoiceType, InvoiceTypeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.InOutCode, opt => opt.MapFrom(src => src.InOutCode))
            .ForMember(dest => dest.NumberStart, opt => opt.MapFrom(src => src.NumberStart))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => !Equals(srcMember, destMember))
        );
        CreateMap<InvoiceTypeCreateDto, InvoiceType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.InOutCode, opt => opt.MapFrom(src => src.InOutCode))
            .ForMember(dest => dest.NumberStart, opt => opt.MapFrom(src => src.NumberStart))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ReverseMap();
        CreateMap<InvoiceTypeUpdateDto, InvoiceType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.InOutCode, opt => opt.MapFrom(src => src.InOutCode))
            .ForMember(dest => dest.NumberStart, opt => opt.MapFrom(src => src.NumberStart))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ReverseMap();
    }
}
