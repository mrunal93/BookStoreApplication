using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayerBookStore
{
    public class CartModelClass
    {
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
        public int OrderNumber { get; set; }
    }
}
