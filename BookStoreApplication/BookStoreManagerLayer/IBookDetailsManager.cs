using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public interface IBookDetailsManager
    {
        BooksDetailsModel AddBookDetails(BooksDetailsModel books);
        BooksDetailsModel UpdateBookDetails(BooksDetailsModel books);
    }
}
