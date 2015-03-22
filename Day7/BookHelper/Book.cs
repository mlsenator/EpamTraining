using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public class Book : IEquatable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        private Book() { }
        public Book(string author, string title, int year, int pages)
        {
            Author = author;
            Title = title;
            Year = year;
            Pages = pages;
        }
        bool IEquatable<Book>.Equals(Book book)
        {
            if (Object.ReferenceEquals(this, null))
                throw new NullReferenceException("Can't check equality. Book is null.");
            if (Object.ReferenceEquals(book, null))
                return false;
            if (this.Author == book.Author && this.Title == book.Title && this.Year == book.Year && this.Pages == book.Pages)
                return true;
            else return false;
        }
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, null))
                throw new NullReferenceException("Can't check equality. Book is null.");
            if (Object.ReferenceEquals(obj, null))
                return false;
            Book book = obj as Book;
            if (book == null)
                return false;
            else return ((IEquatable<Book>)this).Equals(book);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Book b1, Book b2)
        {
            if (Object.Equals(b1, null) && Object.Equals(b2, null))
                return true;
            if (Object.Equals(b1, null) || Object.Equals(b2, null))
                return false;
            if (Object.ReferenceEquals(b1, b2) == true)
                return true;
            return b1.Equals(b2);
        }
        public static bool operator !=(Book b1, Book b2)
        {
            return !(b1 == b2);
        }

    }
}
