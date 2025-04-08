using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Contracts.Request
{
    public class SaleRequestDto
    {
        public List<SaleItemDto> Items { get; set; } = new();
        public decimal Discount { get; set; }
        public string PaymentMethod { get; set; } = "Cash"; 
    }

    public class SaleItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
