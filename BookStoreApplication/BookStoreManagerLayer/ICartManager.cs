using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
     public  interface ICartManager
    {
        CartModelClass GetBookCart(CartModelClass cart);
        CartModelClass DeleteCart(CartModelClass whis);
        CartModelClass AddCart(CartModelClass whis);
        CartModelClass UpdateCart(CartModelClass whis);
    }
}
