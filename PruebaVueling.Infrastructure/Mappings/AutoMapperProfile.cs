using AutoMapper;
using PruebaVueling.Infrastructure.DTOs;
using PruebaVueling.Data.Entities;

namespace PruebaVueling.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Transactions, TransactionsDto>();
            CreateMap<TransactionsDto, Transactions>();

            CreateMap<Rates, RatesDto>();
            CreateMap<RatesDto, Rates>();
        }
    }
}
