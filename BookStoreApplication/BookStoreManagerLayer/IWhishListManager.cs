using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public interface IWhishListManager
    {
        WishListModelClass GetWhishList(WishListModelClass cart);
        WishListModelClass AddWhishList(WishListModelClass whis);
        WishListModelClass UpdateWhishList(WishListModelClass whis);
        WishListModelClass DeleteWhishList(WishListModelClass whis);
    }
}
