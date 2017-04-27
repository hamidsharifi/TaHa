using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rocoland.Models;

namespace Rocoland.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
    
        private readonly ApplicationDbContext _context;
        public IOrderRepository Orders { get; set; }
        public IProductRepository Products { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}