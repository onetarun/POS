﻿using Microsoft.EntityFrameworkCore;
using POS.API.Data;
using POS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly POSContext _context;
        public ProductRepository(POSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.Id);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Barcode = product.Barcode;
            existing.PurchasePrice = product.PurchasePrice;
            existing.SellingPrice = product.SellingPrice;
            existing.StockQuantity = product.StockQuantity;
            existing.LowStockAlert = product.LowStockAlert;
            existing.Description = product.Description;
            existing.ImageUrl = product.ImageUrl;
            existing.IsActive = product.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
