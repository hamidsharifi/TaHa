using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocoland.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        
        [Greaterthan18]
        public string Name { get; set; }

        public int ProductTypeName { get; set; }
        public int ProductTypeId { get; set; }

        public decimal Price { get; set; }

        public string PictrureId { get; set; }
        public int ProducerId { get; set; }
        public int ProducerName { get; set; }
        public string Description { get; set; }
    }
}