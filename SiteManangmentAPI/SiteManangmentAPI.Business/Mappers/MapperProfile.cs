
using AutoMapper;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Enums;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserRequest, User>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                        .ForMember(dest => dest.InsertTime, opt => opt.Ignore()) 
                        .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true)); 


        CreateMap<Apartment, ApartmentResponse>()
            .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.OwnerUser.Username))
            .ForMember(dest => dest.TenantUserName, opt => opt.MapFrom(src => src.TenantUser.Username));
        CreateMap<ApartmentRequest, Apartment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InsertTime, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerUser, opt => opt.Ignore())
                .ForMember(dest => dest.TenantUser, opt => opt.Ignore())
                .ForMember(dest => dest.Bills, opt => opt.Ignore());

        CreateMap<Billing, BillingResponse>()
            .ForMember(dest => dest.ApartmentID, opt => opt.MapFrom(src => src.Apartment.ApartmentNumber));
        CreateMap<BillingRequest, Billing>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());


        CreateMap<Payment, PaymentResponse>()
           .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.User.Username));
        CreateMap<PaymentRequest, Payment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Contact, ContactResponse>();
        CreateMap<ContactRequest, Contact>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
            

        CreateMap<Message, MessageResponse>();
        CreateMap<MessageRequest, Message>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false)); 

    }
}