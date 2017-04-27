using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Rocoland.Models;

namespace Rocoland.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductAPIController : ApiController
    {
        ApplicationDbContext _context;

        public ProductAPIController()
        {
            _context = new ApplicationDbContext();
        }

        // DELETE: api/ProductAPI/5
        [HttpDelete]
        [Authorize(Roles = "Administrators")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);

            //var p = _context.Products.Single(m => m.Id == id);
            //if (p == null)
            //{
            //    return NotFound();
            //}

            //_context.Products.Remove(p);
            //_context.SaveChanges();

            //return Ok();
        }
    }
}
