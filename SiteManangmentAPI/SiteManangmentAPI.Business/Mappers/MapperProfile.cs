
using AutoMapper;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Data.Entities;

namespace SiteManangmentAPI.Business.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserRequest, User>();

        CreateMap<Apartment, ApartmentResponse>();
        CreateMap<ApartmentRequest, Apartment>();

        CreateMap<Billing, BillingResponse>();
        CreateMap<BillingRequest, Billing>();

        CreateMap<Payment, PaymentResponse>();
        CreateMap<PaymentRequest, Payment>();

        CreateMap<Contact, ContactResponse>();
        CreateMap<ContactRequest, Contact>();

        CreateMap<Message, MessageResponse>();
        CreateMap<MessageRequest, Message>();

    }
}