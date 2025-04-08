using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        [ForeignKey("Sale")]
        public int SaleId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public Sale? Sale { get; set; }
        public Product? Product { get; set; }
    }
}
