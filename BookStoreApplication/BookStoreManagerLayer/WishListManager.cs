using ModelLayerBookStore;
using RepositoryLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public class WishListManager : IWhishListManager
    {
        public readonly WishListRepository wishList;

        public WishListManager (WishListRepository wishList)
        {
            this.wishList = wishList;
        }

        public WishListModelClass GetWhishList(WishListModelClass cart)
        {
            return wishList.GetWhishList(cart);
        }
        public WishListModelClass AddWhishList(WishListModelClass whis)
        {
            return wishList.AddWhishList(whis);
        }
        public WishListModelClass UpdateWhishList(WishListModelClass whis)
        {
            return wishList.UpdateWhishList(whis);
        }
        public WishListModelClass DeleteWhishList(WishListModelClass whis)
        {
            return wishList.DeleteWhishList(whis);
        }
    }
}
