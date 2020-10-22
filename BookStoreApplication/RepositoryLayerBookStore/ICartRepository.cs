using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface ICartRepository
    {
        CartModelClass BookCart(CartModelClass cart);
    }
}
