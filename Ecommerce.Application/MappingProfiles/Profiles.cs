using AutoMapper;
using Ecommerce.Application.InputModel;
using Ecommerce.Application.ViewModel;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.MappingProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Product,CreateProductModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ForMember(dest => dest.BrandId,cfg => cfg.MapFrom(src => src.BrandId ?? Guid.Empty)).ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
