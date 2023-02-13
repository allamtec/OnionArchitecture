using Microsoft.EntityFrameworkCore;
using OA.Core.Data;
using OA.Core.Models;
using OA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class OrderRepository : Repository<Order>, Interfaces.IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Order GetFullOrder(int Id)
        {
            return entities.Include(x => x.OrderDetails).Where(x => x.Id == Id).SingleOrDefault();
        }
    }

}
