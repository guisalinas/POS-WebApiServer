using AutoMapper;
using POS_ApiServer.DTOs.Address;
using POS_ApiServer.DTOs.Customer;
using POS_ApiServer.DTOs.Product;
using POS_ApiServer.Models;

namespace POS_ApiServer.Data
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            //Address
            CreateMap<AddressDTO, Address>().ReverseMap();

            //Customer
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.addresses, opt => opt.MapFrom(src => src.addresses))
                .ReverseMap(); 

            CreateMap<GetCustomerDTO, Customer>().ReverseMap();


            CreateMap<LogicalDeleteCustomerDTO, Customer>().ReverseMap();

            //Product
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<GetProductDTO, Product>().ReverseMap();
            CreateMap<LogicalDeleteProductDTO, Product>().ReverseMap();

        }
    }
}
