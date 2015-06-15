using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public class Book : IEquatable<Book>, IComparable<Book>
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }
        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, null))
                throw new NullReferenceException("Can't check equality. Book is null.");
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (this.Author == other.Author && this.Title == other.Title && this.Year == other.Year && this.Pages == other.Pages)
                return true;
            else return false;
        }
        public static bool operator ==(Book left, Book right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null))
                return false;

            return left.Equals(right);
        }
        public static bool operator !=(Book left, Book right)
        {
            if (ReferenceEquals(left, right))
                return false;

            if (ReferenceEquals(left, null))
                return true;

            return !left.Equals(right);
        }
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, null))
                throw new NullReferenceException("Can't compare. Book is null.");
            if (ReferenceEquals(other, null)) return 1;
            return this.Year.CompareTo(other.Year);
        }
    }
}
