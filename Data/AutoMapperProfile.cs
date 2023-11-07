using AutoMapper;
using POS_ApiServer.DTOs.Customer;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;

namespace POS_ApiServer.Data
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<GetProductDTO, Product>().ReverseMap();
            CreateMap<LogicalDeleteProductDTO, Product>().ReverseMap();

            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<GetCustomerDTO, Customer>().ReverseMap();
            CreateMap<LogicalDeleteCustomerDTO, Customer>().ReverseMap();

        }
    }
}
