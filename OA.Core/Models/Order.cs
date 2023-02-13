using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Core.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails= new List<OrderDetail>();

        }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
