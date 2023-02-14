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
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailDto, OrderDetail>();//.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProductId, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailDto>();//.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));
        }
    }
}
