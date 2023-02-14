using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OA.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Order>().HasData(new Order[] {
            //    new Order{Customer="Sayed",Phone=01224906035,
            //    OrderDetails=new OrderDetail[]
            //    {
            //        new OrderDetail{ItemNo="i 1",Description="desc 1",Quantity=1,Price=10 },
            //        new OrderDetail{ItemNo="i 2",Description="desc 1",Quantity=2,Price=20 },
            //        new OrderDetail{ItemNo="i 3",Description="desc 1",Quantity=2,Price=30 },

            //    }},

            //    new Order{Customer="Allam",Phone=23435665,
            //    OrderDetails=new OrderDetail[]
            //    {
            //        new OrderDetail{ItemNo="i 1",Description="desc 1",Quantity=1,Price=10 },
            //        new OrderDetail{ItemNo="i 2",Description="desc 1",Quantity=2,Price=20 },

            //    }},
            //});

        }
        public DbSet<OrderDetail> OrderDetails
        {
            get;
            set;
        }

        public DbSet<Order> Orders
        {
            get;
            set;
        }

    }
}
