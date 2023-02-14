using AutoMapper;
using OA.Core.Dto;
using OA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>();//.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProductId, opt => opt.Ignore());
            CreateMap<Order, OrderDto>();//.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));
        }
    }
}
