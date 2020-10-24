using ModelLayerBookStore;
using RepositoryLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public class BookManager
    {
        public readonly IBookDetailsRepository bookDetails;
        public BookManager(IBookDetailsRepository bookDetails)
        {
            this.bookDetails = bookDetails;
        }

        public BooksDetailsModel AddBookDetails(BooksDetailsModel books)
        {
            return bookDetails.AddBookDetails(books);
        }
        public BooksDetailsModel UpdateBookDetails(BooksDetailsModel books)
        {
            return bookDetails.UpdateBookDetails(books);
        }
    }
}
