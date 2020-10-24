using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface IBookDetailsRepository
    {
        BooksDetailsModel AddBookDetails(BooksDetailsModel books);
        BooksDetailsModel UpdateBookDetails(BooksDetailsModel books);
    }
}
