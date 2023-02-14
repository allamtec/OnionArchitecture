using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Core.Dto
{
    public class OrderDto : BaseDto
    {
        public OrderDto()
        {
            OrderDetails= new List<OrderDetailDto>();

        }
        public string Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public string Address { get; set; }
        public int Phone { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; }

    }
}
