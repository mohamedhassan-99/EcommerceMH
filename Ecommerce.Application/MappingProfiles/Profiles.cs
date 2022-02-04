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
            CreateMap<Product,ProductInputModel>().ReverseMap();
            CreateMap<Brand,BrandInputModel>().ReverseMap();
            CreateMap<Category,CategoryInputModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
