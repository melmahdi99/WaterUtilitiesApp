using Domain;
using AutoMapper;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Billing, ReadBillingDto>();
        CreateMap<CreateBillingDto, Billing>();
        CreateMap<Billing, FullBillingDto>();
        CreateMap<FullBillingDto, Billing>();
    }
}