using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using OA.Core.Dto;
using OA.Core.Models;
using OA.Repository.Interfaces;

namespace OA.Services.Interfaces
{
    public interface IOrderService 
    {
        IEnumerable<OrderDto> GetAll();
        OrderDto Get(int Id);
        OrderDto GetFullOrder(int Id);
        void Insert(OrderDto entity);
        void Update(OrderDto entity);
        void Delete(OrderDto entity);
        void Remove(OrderDto entity);
        void SaveChanges();
    }

}
