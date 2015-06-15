using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using BookHelper.Repository;
using BookHelper.Entity;

namespace BookHelper.Logic
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
            // maybe this method shouldn't be called here
            // because if we want to create new instance of service without data file
            // it will always try to open file (filePath link) which is not exist
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
        public IEnumerable<Book> SaveIntoNewRepository(IBookRepository newRepository, Func<Book, bool> predicate)
        {
            if (newRepository == null) throw new ArgumentNullException("Null repository.");
            IEnumerable<Book> books;
            if (predicate == null)
                books = repository.LoadBooks();
            else
                books = repository.LoadBooks().Where<Book>(predicate);
            newRepository.SaveBooks(books);
            return books;
        }

        public bool Export(IXmlFormatExporter xmlExporter, string fileName)
        {
            if (xmlExporter == null)
            {
                logger.Error("Can't export books. XML exporter is null");
                return false;
            }
            xmlExporter.Export(books, fileName);
            return true;
        }
    }
}
