using OA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetFullOrder(int Id);
    }
}
