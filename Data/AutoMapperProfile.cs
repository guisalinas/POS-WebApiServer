using AutoMapper;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;

namespace POS_ApiServer.Data
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<addProductDTO, Product>().ReverseMap();
            CreateMap<updateProductDTO, Product>().ReverseMap();

        }
    }
}
