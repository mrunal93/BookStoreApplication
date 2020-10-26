using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface ICartRepository
    {
        CartModelClass GetBookCart(CartModelClass cart);
        CartModelClass DeleteCart(CartModelClass whis);
        CartModelClass AddCart(CartModelClass whis);
        CartModelClass UpdateCart(CartModelClass whis);
    }
}
