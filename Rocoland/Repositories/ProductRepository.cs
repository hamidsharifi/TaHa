using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rocoland.Models;

namespace Rocoland.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
        {
        }
    }
}