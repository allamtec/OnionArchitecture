using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using OA.Core.Models;
using OA.Repository.Interfaces;

namespace OA.Services.Interfaces
{
    public interface IOrderService : IRepository<Order>
    {
        Order GetFullOrder(int Id);
    }

}
