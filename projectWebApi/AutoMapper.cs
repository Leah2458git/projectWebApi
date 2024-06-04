using AutoMapper;
using DTOs;
using Entities;
using Repositories;
using System.Runtime.InteropServices;

namespace projectWebApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest=> dest.CategoryName,
                opt=>opt.MapFrom(src=>src.Category.CategoryName)).ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }


    }
}
