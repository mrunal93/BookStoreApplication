using System;

namespace ModelLayerBookStore
{
    public class BooksDetailsModel
    {
        public int BookId { get; set; }
        public string BookImages { get; set; }
        public string BookDescription { get; set; }
        public int AddToWishList { get; set; }
        public int BookPrice { get; set; }
        public int BookQuantity { get; set; }
        public string BookAutherName { get; set; }
    }
}
