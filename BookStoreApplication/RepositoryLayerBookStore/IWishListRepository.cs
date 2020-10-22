using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
   public interface IWishListRepository
    {
        WishListModelClass BookCart(WishListModelClass cart);
    }
}
