using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Core.Dto;

namespace OA.Core.Dto
{
    public class OrderDetailDto : BaseDto
    {
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get { return Quantity * Price; } }



    }
}
