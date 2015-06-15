using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHelper.Repository;
using BookHelper.Logic;
using BookHelper.Entity;

namespace BookHelperConsoleUI
{
    class BookHelperUI
    {
        static void Main(string[] args)
        {
            BookListService service1 = new BookListService(new BinaryFileRepository(@"D:\test.bin"));
            BookListService service2 = new BookListService(new BinarySerializationRepository (@"D:\test.xml"));
            Book[] books = new Book[] { new Book("authorC", "titleC", 1992, 100),new Book("authorD", "titleD", 1993, 100),
                                        new Book("authorA", "titleA", 1990, 100), new Book("authorB", "titleB", 1991, 100),
                                        new Book("authorE", "titleE", 1994, 100),new Book("authorF", "titleF", 1995, 100)};
            foreach (var b in books)
            {
                service1.AddBook(b);
                service2.AddBook(b);
            }
            service1.RemoveBook(books[3]);
            service1.SortBooks(new YearBookComparator());
            service1.SaveChanges();
            service2.RemoveBook(books[3]);
            service2.SortBooks(new YearBookComparator());
            service2.SaveChanges();

            BookListService serviceBuf1 = new BookListService(new BinaryFileRepository(@"D:\test.bin"));
            BookListService serviceBuf2 = new BookListService(new BinarySerializationRepository(@"D:\test.xml"));
            var res1 = serviceBuf1.ReadAllBooks();
            foreach (var b in res1)
            {
                Console.WriteLine("{0}   {1}   {2}   {3}", b.Author, b.Title, b.Year, b.Pages);
            }
            Console.WriteLine("\n**************************\n");
            var res2 = serviceBuf2.ReadAllBooks();
            foreach (var b in res2)
            {
                Console.WriteLine("{0}   {1}   {2}   {3}", b.Author, b.Title, b.Year, b.Pages);
            }
            serviceBuf2.Export(new LinqToXmlExporter(), @"D:\exportTest1.xml");
            serviceBuf2.Export(new XmlWriterExporter(), @"D:\exportTest2.xml");


            Console.ReadLine();
        }
    }
}
