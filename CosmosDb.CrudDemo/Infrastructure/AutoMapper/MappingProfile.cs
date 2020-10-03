using AutoMapper;
using CosmosDb.CrudDemo.Dto;
using CosmosDb.CrudDemo.Models;

namespace MusicDistro.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Stock, StockDto>();
        }
    }
}