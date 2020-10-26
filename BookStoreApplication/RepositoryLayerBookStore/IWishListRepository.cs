using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface IWishListRepository
    {
        WishListModelClass GetWhishList(WishListModelClass cart);
        WishListModelClass AddWhishList(WishListModelClass whis);
        WishListModelClass UpdateWhishList(WishListModelClass whis);
        WishListModelClass DeleteWhishList(WishListModelClass whis);
    }
        
}
