using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookHelper
{
    public class BookListService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<Book> books;
        private IBookRepository repository;

        public BookListService(IBookRepository repository)
        {
            if (repository == null)
            {
                logger.Error("Null repository.");
                    throw new ArgumentNullException("Null repository");
            }
            this.repository = repository;
            books = repository.LoadBooks().ToList();
        }
        public bool AddBook(Book book)
        {
            if (book == null)
            {
                logger.Error("Can't add. Book is null");
                return false;
            }
            foreach (Book b in books)
            {
                if (book.Equals(b)) return false;
            }
            books.Add(book);
            return true;
        }
        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
                logger.Error("Can't remove. Book is null");
                return false;
            }

            return books.Remove(book);
        }
        public List<Book> ReadAllBooks()
        {
            return books;
        }
        public bool SaveChanges()
        {
            return repository.SaveBooks(books);
        }
        public void SortBooks(IComparer<Book> comparer)
        {
            if (comparer == null)
                logger.Error("Null comparer. Default comparer will be used");
            books.Sort(comparer);
        }
        public int IndexOf(Book book)
        {
            if (book == null)
            {
                logger.Error("Can't find index. Book is null");
                return -1;
            }
            return books.IndexOf(book);
        }
    }
}
