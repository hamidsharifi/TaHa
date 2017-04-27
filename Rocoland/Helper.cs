using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rocoland.Models;

namespace Rocoland
{
    public static class Helper
    {
        public static IEnumerable<ProductType> GetProductType()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            return _context.ProductTypes.ToList();
        }
    }
}