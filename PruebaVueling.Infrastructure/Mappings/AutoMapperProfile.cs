using AutoMapper;
using PruebaVueling.Core.DTOs;
using PruebaVueling.Core.Entities;

namespace PruebaVueling.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Transactions, TransactionDto>();
            CreateMap<TransactionDto, Transactions>();
        }
    }
}
