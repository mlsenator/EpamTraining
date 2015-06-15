using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHelper;

namespace BookHelperConsoleUI
{
    class BookHelperUI
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService(new BinaryFileRepository(@"D:\test.bin"));
            Book[] books = new Book[] { new Book("authorC", "titleC", 1992, 100),new Book("authorD", "titleD", 1993, 100),
                                        new Book("authorA", "titleA", 1990, 100), new Book("authorB", "titleB", 1991, 100),
                                        new Book("authorE", "titleE", 1994, 100),new Book("authorF", "titleF", 1995, 100)};
            foreach (var b in books)
                service.AddBook(b);
            service.RemoveBook(books[3]);
            service.SortBooks(new YearBookComparator());
            service.SaveChanges();
            //service.IndexOf(null);
            BookListService serviceBuf = new BookListService(new BinaryFileRepository(@"D:\test.bin"));
            var res = serviceBuf.ReadAllBooks();
            foreach (var b in res)
            {
                Console.WriteLine("{0}   {1}   {2}", b.Author, b.Title, b.Year);
            }

            //BookListService serviceBuf2 = new BookListService(null);

            Console.ReadLine();
        }
    }
}
