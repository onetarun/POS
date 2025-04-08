using POS.API.Contracts.Request;
using POS.API.Contracts.Response;
using POS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Extensions
{
    public static class ProductMappingExtensions
    {
        public static Product ToEntity(this ProductRequestDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Barcode = dto.Barcode,
                PurchasePrice = dto.PurchasePrice,
                SellingPrice = dto.SellingPrice,
                StockQuantity = dto.StockQuantity,
                LowStockAlert = dto.LowStockAlert,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static ProductResponseDto ToDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Barcode = product.Barcode,
                SellingPrice = product.SellingPrice,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }

        public static void UpdateFromDto(this Product product, ProductRequestDto dto)
        {
            product.Name = dto.Name;
            product.Barcode = dto.Barcode;
            product.PurchasePrice = dto.PurchasePrice;
            product.SellingPrice = dto.SellingPrice;
            product.StockQuantity = dto.StockQuantity;
            product.LowStockAlert = dto.LowStockAlert;
            product.Description = dto.Description;
            product.ImageUrl = dto.ImageUrl;
            product.IsActive = dto.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
        }
    }
}
