using ModelLayerBookStore;
using RepositoryLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public class CartManager : ICartManager
    {
        public readonly CartRepository cart;

        public CartManager(CartRepository cart)
        {
            this.cart = cart;
        }

        public CartModelClass GetBookCart(CartModelClass carthad)
        {
            return cart.GetBookCart(carthad);
        }
        
        public CartModelClass DeleteCart(CartModelClass whis)
        {
            return cart.DeleteCart(whis);
        }
        
        public CartModelClass AddCart(CartModelClass whis)
        {
            return cart.AddCart(whis);
        }
        
        public CartModelClass UpdateCart(CartModelClass whis)
        {
            return cart.UpdateCart(whis);
        }
    }
}
