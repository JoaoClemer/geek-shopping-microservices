using AutoMapper;
using GeekShopping.ProductAPI.Data.DataTransferObjects;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
