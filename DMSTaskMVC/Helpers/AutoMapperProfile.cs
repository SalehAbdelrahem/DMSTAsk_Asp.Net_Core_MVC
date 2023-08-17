using AutoMapper;
using BLL.DTOs.CustomFields;
using BLL.DTOs.Categories;
using BLL.DTOs.CustomFieldDatas;
using BLL.DTOs.Products;
using DAL.Models;

namespace DMSTaskMVC.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Category,CategoryDTO>().ReverseMap();
           CreateMap<Product, ProductDTO>().ReverseMap();
           CreateMap<Product, EditProductDTO>().ReverseMap();
           CreateMap<Product, DetailsProductDTO>().ReverseMap();
          
           CreateMap<CustomField, CustomFieldDTO>().ReverseMap();
           CreateMap<CustomField, DetailscustomFieldDTO>().ReverseMap();
           CreateMap<CustomFieldData, CustomFieldDataDTO>().ReverseMap();

        }

    }
}
